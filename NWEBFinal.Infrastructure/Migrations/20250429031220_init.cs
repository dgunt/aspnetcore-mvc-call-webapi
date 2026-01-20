using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NWEBFinal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.CheckConstraint("CK_Students_DateOfBirth_Past", "[DateOfBirth] < CAST(GETDATE() AS date)");
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "DateOfBirth", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hà Nội", new DateOnly(2000, 1, 1), "vana@example.com", "Nguyễn Văn A", "0901111222" },
                    { 2, "TP.HCM", new DateOnly(2001, 2, 2), "thib@example.com", "Trần Thị B", "0902222333" },
                    { 3, "Đà Nẵng", new DateOnly(1999, 3, 3), "vanc@example.com", "Lê Văn C", "0903333444" },
                    { 4, "Cần Thơ", new DateOnly(2002, 4, 4), "thid@example.com", "Phạm Thị D", "0904444555" },
                    { 5, "Hải Phòng", new DateOnly(2000, 5, 5), "vane@example.com", "Hoàng Văn E", "0905555666" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
