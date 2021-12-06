using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Nomina_empleado.Models
{
    public partial class NOMINA_DBContext : DbContext
    {
        public NOMINA_DBContext()
        {
        }

        public NOMINA_DBContext(DbContextOptions<NOMINA_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobHistory> JobHistories { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__admins__89472E95997798E6");

                entity.ToTable("admins");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Pass)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Users)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("users");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.IdentificationCard, "UQ__Employee__72294EEC793513AB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification_card");

                entity.Property(e => e.NameEmployee)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name_employee");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleEmployee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_employee");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.HasKey(e => e.IdJobHistory)
                    .HasName("PK__job_hist__7B561F5E1A6416B0");

                entity.ToTable("job_history");

                entity.HasIndex(e => e.IdentificationCard, "UQ__job_hist__72294EECD6D75B82")
                    .IsUnique();

                entity.Property(e => e.IdJobHistory).HasColumnName("id_job_history");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification_card");

                entity.Property(e => e.NameEmployee)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name_employee");

                entity.Property(e => e.RoleEmployee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_employee");
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("Payroll");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Afp)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("AFP");

                entity.Property(e => e.DatePayroll)
                    .HasColumnType("date")
                    .HasColumnName("date_payroll")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.NetIncome).HasColumnName("net_income");

                entity.Property(e => e.Secure)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("secure");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Payroll__id_empl__6383C8BA");
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.HasKey(e => e.IdVacations)
                    .HasName("PK__Vacation__3F48DFDFE50E502C");

                entity.HasIndex(e => e.IdentificationCard, "UQ__Vacation__72294EECF6923940")
                    .IsUnique();

                entity.Property(e => e.IdVacations).HasColumnName("id_Vacations");

                entity.Property(e => e.FromVacations)
                    .HasColumnType("date")
                    .HasColumnName("from_vacations");

                entity.Property(e => e.IdentificationCard)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification_card");

                entity.Property(e => e.StatusVacation)
                    .HasColumnName("status_vacation")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ToVacations)
                    .HasColumnType("date")
                    .HasColumnName("to_vacations");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
