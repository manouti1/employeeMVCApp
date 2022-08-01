using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDemoApp.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserToken");
            });

            builder.Entity<UserPosition>().HasKey(sc => new { sc.EmployeeId, sc.PositionId });

            builder.Entity<UserPosition>()
             .HasOne<Employee>(sc => sc.Employee)
             .WithMany(s => s.UserPositions)
             .HasForeignKey(sc => sc.EmployeeId)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();


            builder.Entity<UserPosition>()
                .HasOne<Position>(sc => sc.Position)
                .WithMany(s => s.UserPositions)
                .HasForeignKey(sc => sc.PositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


            builder.Entity<Department>()
             .HasIndex(d => d.Code).IsUnique();
            builder.Entity<Department>()
              .Property(p => p.Code)
              .HasMaxLength(5)
              .IsRequired();

            builder.Entity<Department>()
               .Property(p => p.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.Entity<Department>().HasData(
                 new Department { Id = Guid.NewGuid(), Name = "HR", Code = "HR" },
                 new Department { Id = Guid.NewGuid(), Name = "Administration", Code = "ADMIN" },
                 new Department { Id = Guid.NewGuid(), Name = "Software Development", Code = "DEV" }
            );

            builder.Entity<Position>().HasData(
                new Position { Id = Guid.NewGuid(), Name = "HR" },
                new Position { Id = Guid.NewGuid(), Name = "Administrator" },
                new Position { Id = Guid.NewGuid(), Name = "Web Developer" },
                new Position { Id = Guid.NewGuid(), Name = "Manager" }
            );

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UserPosition> UserPosition { get; set; }
    }

}

