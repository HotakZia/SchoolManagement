using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagement.Models;


namespace SchoolManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddViewOptions(options => { options.HtmlHelperOptions.ClientValidationEnabled = true; }); //unobot jquery
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

            });
        
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Enable runtime compilation for Razor views
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.IsEssential = true;
            });


            //  services.AddAuthentication("CookieAuthentication")
            //                   .AddCookie("CookieAuthentication", config =>
            //                   {
            //                       config.Cookie.Name = "UserLoginCookie"; // Name of cookie     
            //                       config.LoginPath = "/Account/Login"; // Path for the redirect to user login page    
            //                       config.AccessDeniedPath = "/Account/AccessDenied";
            //                       config.ExpireTimeSpan = TimeSpan.FromHours(24); // Cookie expiration time
            //                       config.SlidingExpiration = true;// Extend expiration on each request
            //                   });

            //  services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //{
            //    // Configure cookie options if needed
            //    options.Cookie.Name = "YourCookieName";
            //    options.Cookie.HttpOnly = true;
            //});
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
  {
      config.Cookie.Name = "UserLoginCookie"; // Name of the cookie
    config.LoginPath = "/Account/Login"; // Path for the redirect to the user login page
    config.AccessDeniedPath = "/Account/AccessDenied";
      config.ExpireTimeSpan = TimeSpan.FromHours(24); // Cookie expiration time
    config.SlidingExpiration = true; // Extend expiration on each request
});

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.DateOfBirth);
                });
            });

            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            // Pascal casing
            services.AddControllersWithViews().
                    AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/httpError");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //http errors
            app.UseStatusCodePagesWithRedirects("/httpError?code={0}");
            // Configure custom page for unauthorized access
            //app.UseStatusCodePagesWithRedirects("/Unauthorized");


            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    // Set cache-control headers for static files
                    context.Context.Response.Headers["Cache-Control"] = "public,max-age=604800"; // Cache for 1 week
                }
            });


            app.UseResponseCaching();
            app.UseStaticFiles(); // Ensure this is configured correctly
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
