using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class School_dbContext : DbContext
    {
        public School_dbContext()
        {
        }

        public School_dbContext(DbContextOptions<School_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAssignee> BookAssignees { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentPayment> StudentPayments { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TableCompany> TableCompanies { get; set; }
        public virtual DbSet<TableRole> TableRoles { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Dell; Initial Catalog=School_db;user=sa;password=123; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.In).HasColumnName("_IN");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Out).HasColumnName("_OUT");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<BookAssignee>(entity =>
            {
                entity.ToTable("BookAssignee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Grad).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Room).HasMaxLength(50);

                entity.Property(e => e.Shift).HasMaxLength(50);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Attendance).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.ClassActivity).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstApprovalTime).HasColumnType("datetime");

                entity.Property(e => e.FirstExam).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.HomeActivity).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.SecondApprovalTime).HasColumnType("datetime");

                entity.Property(e => e.SecondExam).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.ThiredApprovalTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FeeType).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.ToTable("Holiday");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Hostel>(entity =>
            {
                entity.ToTable("Hostel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Block).HasMaxLength(50);

                entity.Property(e => e.CostPerBed).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Room).HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Condition).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("InvoiceID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Contact).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Occupation).HasMaxLength(250);

                entity.Property(e => e.Province).HasMaxLength(250);

                entity.Property(e => e.Relationship).HasMaxLength(250);

                entity.Property(e => e.Street).HasMaxLength(250);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(250);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Shift).HasMaxLength(50);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sport");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Postition).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.AdmissionDate).HasColumnType("datetime");

                entity.Property(e => e.BloodGroup).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Contact).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FatherName).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(250);

                entity.Property(e => e.GfatherName)
                    .HasMaxLength(250)
                    .HasColumnName("GFatherName");

                entity.Property(e => e.GuardianName).HasMaxLength(250);

                entity.Property(e => e.GuardianPhone).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Province).HasMaxLength(250);

                entity.Property(e => e.RoleNumber).HasMaxLength(50);

                entity.Property(e => e.Shift).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(250);

                entity.Property(e => e.Tazkira).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentPayment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectName).HasMaxLength(250);
            });

            modelBuilder.Entity<TableCompany>(entity =>
            {
                entity.ToTable("Table_Company");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FacebookName).HasMaxLength(250);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LogoName).HasMaxLength(50);

                entity.Property(e => e.LogoType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.TagLine).HasMaxLength(250);

                entity.Property(e => e.TwitterName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TableRole>(entity =>
            {
                entity.ToTable("Table_Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleType).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("Tbl_User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Gender).HasMaxLength(250);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(250);

                entity.Property(e => e.RoleNumber).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.Street).HasMaxLength(250);

                entity.Property(e => e.SubjectTaught).HasMaxLength(250);

                entity.Property(e => e.Tazkira).HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PaidBy).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.RouteName).HasMaxLength(50);

                entity.Property(e => e.VechicleNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Modefied).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
