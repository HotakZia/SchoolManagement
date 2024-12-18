using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SchoolManagement.Models
{
    /// <summary>
    /// how to connecto to Database
    /// </summary>
    //Scaffold-DbContext "Data Source=Dell; Initial Catalog=School_db;user=sa;password=123; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/db -force

    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
       
        public string ClaimType { get; }
        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
    public static class AuthorizationPolicyBuilderExtension
    {
        public static AuthorizationPolicyBuilder UserRequireCustomClaim(this AuthorizationPolicyBuilder builder, string claimType)
        {
            builder.AddRequirements(new CustomUserRequireClaim(claimType));
            return builder;
        }
    }
    public class PoliciesAuthorizationHandler : AuthorizationHandler<CustomUserRequireClaim>
    {
       
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CustomUserRequireClaim requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var hasClaim = context.User.Claims.Any(x => x.Type == requirement.ClaimType);

            if (hasClaim)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        public SchoolManagement.Models.db.School_dbContext db= new db.School_dbContext();
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
           
                var claims = context.User.Claims;
                var roles = requirement.AllowedRoles;
                var requiredRoles = roles.ToList();
                //validRole = claims.Where(c => c.Type == "Roles"&&c.Value==requiredRoles).Select(x=>x.Value).Any();

                foreach (var item in requiredRoles)
                {
                    if (claims.Where(c => c.Type == "Roles" && c.Value == item).Select(x => x.Value).Any())
                    {
                        validRole = true;
                    }
                }
                
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DateOfBirth { get; set; }
        public bool RememberMe { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>() { new Users { Id = 101, UserName = "anet", Name = "Anet", EmailId = "anet@test.com", Password = "anet123", Role = "Admin", DateOfBirth = "01/01/2012" } };
        }
    }

}
