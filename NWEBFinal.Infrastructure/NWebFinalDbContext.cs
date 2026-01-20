using Microsoft.EntityFrameworkCore;
using NWEBFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Infrastructure
{
    public class NWebFinalDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        public NWebFinalDbContext(DbContextOptions<NWebFinalDbContext> opts)
            : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stu = modelBuilder.Entity<Student>();
            stu.HasKey(s => s.StudentId);
            stu.Property(s => s.StudentId)
                .ValueGeneratedOnAdd();
            stu.Property(s => s.FullName)
               .IsRequired().HasMaxLength(150);
            stu.Property(s => s.DateOfBirth)
               .IsRequired()
               .HasColumnType("date");

            stu.HasCheckConstraint(
        name: "CK_Students_DateOfBirth_Past",
        sql: "[DateOfBirth] < CAST(GETDATE() AS date)"
    );

            stu.Property(s => s.Email)
               .IsRequired().HasMaxLength(100);
            stu.Property(s => s.PhoneNumber)
               .HasMaxLength(20);
            stu.Property(s => s.Address)
               .HasMaxLength(250);

            // ▶ Seed 5 bản ghi
            stu.HasData(
              new Student { StudentId = 1, FullName = "Nguyễn Văn A", DateOfBirth = new DateOnly(2000, 1, 1), Email = "vana@example.com", PhoneNumber = "0901111222", Address = "Hà Nội" },
              new Student { StudentId = 2, FullName = "Trần Thị B", DateOfBirth = new DateOnly(2001, 2, 2), Email = "thib@example.com", PhoneNumber = "0902222333", Address = "TP.HCM" },
              new Student { StudentId = 3, FullName = "Lê Văn C", DateOfBirth = new DateOnly(1999, 3, 3), Email = "vanc@example.com", PhoneNumber = "0903333444", Address = "Đà Nẵng" },
              new Student { StudentId = 4, FullName = "Phạm Thị D", DateOfBirth = new DateOnly(2002, 4, 4), Email = "thid@example.com", PhoneNumber = "0904444555", Address = "Cần Thơ" },
              new Student { StudentId = 5, FullName = "Hoàng Văn E", DateOfBirth = new DateOnly(2000, 5, 5), Email = "vane@example.com", PhoneNumber = "0905555666", Address = "Hải Phòng" }
            );
        }
    }
}
