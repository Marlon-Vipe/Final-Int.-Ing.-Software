using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nomina_empleado.Models
{
    public partial class Employee_ITLA_DBContext : DbContext
    {
        public Employee_ITLA_DBContext()
        {
        }

        public Employee_ITLA_DBContext(DbContextOptions<Employee_ITLA_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<JobHistory> JobHistory { get; set; }
        public virtual DbSet<Payroll> Payroll { get; set; }
        public virtual DbSet<Vacations> Vacations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CRISDESKTOP; Database=Employee_ITLA_DB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__admins__89472E95D6BEA3AD");

                entity.ToTable("admins");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Users)
                    .HasColumnName("users")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.IdentificationCard)
                    .HasName("UQ__Employee__72294EEC225A0631")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasColumnName("identification_card")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameEmployee)
                    .HasColumnName("name_employee")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleEmployee)
                    .HasColumnName("role_employee")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.HasKey(e => e.IdJobHistory)
                    .HasName("PK__job_hist__7B561F5EF1FE4247");

                entity.ToTable("job_history");

                entity.HasIndex(e => e.IdentificationCard)
                    .HasName("UQ__job_hist__72294EEC920CCDBE")
                    .IsUnique();

                entity.Property(e => e.IdJobHistory).HasColumnName("id_job_history");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasColumnName("identification_card")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameEmployee)
                    .HasColumnName("name_employee")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RoleEmployee)
                    .HasColumnName("role_employee")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Afp)
                    .HasColumnName("AFP")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DatePayroll)
                    .HasColumnName("date_payroll")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.Secure)
                    .HasColumnName("secure")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Payroll)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Payroll__id_empl__3A81B327");
            });

            modelBuilder.Entity<Vacations>(entity =>
            {
                entity.HasKey(e => e.IdVacations)
                    .HasName("PK__Vacation__3F48DFDFD6D37BE0");

                entity.HasIndex(e => e.IdentificationCard)
                    .HasName("UQ__Vacation__72294EECB88737D9")
                    .IsUnique();

                entity.Property(e => e.IdVacations).HasColumnName("id_Vacations");

                entity.Property(e => e.FromVacations)
                    .HasColumnName("from_vacations")
                    .HasColumnType("date");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasColumnName("identification_card")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusVacation).HasColumnName("status_vacation");

                entity.Property(e => e.ToVacations)
                    .HasColumnName("to_vacations")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
