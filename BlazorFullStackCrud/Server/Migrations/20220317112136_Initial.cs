using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "DateOfBirth", "Email", "Password", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
                values: new object[] { 1, "", new DateTime(2022, 3, 17, 12, 21, 36, 422, DateTimeKind.Local).AddTicks(7692), "user#domain.com", "", new byte[] { 65, 70, 63, 95, 32, 45, 183, 69, 40, 237, 0, 68, 98, 145, 21, 183, 200, 31, 59, 22, 31, 210, 67, 183, 57, 64, 53, 202, 220, 208, 35, 0, 219, 217, 242, 61, 6, 202, 187, 187, 148, 23, 88, 48, 55, 217, 116, 77, 15, 240, 23, 205, 192, 161, 171, 131, 171, 74, 165, 232, 86, 131, 113, 248 }, new byte[] { 80, 11, 104, 212, 4, 219, 43, 208, 74, 176, 174, 188, 37, 74, 214, 223, 10, 98, 165, 243, 35, 247, 12, 210, 106, 47, 12, 115, 237, 14, 44, 157, 168, 39, 22, 200, 32, 181, 74, 168, 185, 167, 120, 12, 159, 185, 34, 230, 179, 157, 28, 220, 169, 100, 167, 41, 135, 232, 8, 166, 144, 69, 162, 54, 76, 231, 152, 62, 204, 135, 2, 178, 23, 72, 79, 228, 81, 39, 20, 81, 24, 58, 96, 210, 238, 96, 72, 233, 105, 236, 239, 49, 31, 128, 228, 147, 170, 108, 200, 84, 187, 45, 232, 214, 170, 134, 125, 248, 123, 2, 97, 200, 47, 212, 48, 100, 36, 94, 12, 73, 191, 185, 142, 130, 125, 79, 66, 92 }, 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "DateOfBirth", "Email", "Password", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
                values: new object[] { 2, "", new DateTime(2022, 3, 17, 12, 21, 36, 422, DateTimeKind.Local).AddTicks(7699), "user#domain.com", "", new byte[] { 65, 70, 63, 95, 32, 45, 183, 69, 40, 237, 0, 68, 98, 145, 21, 183, 200, 31, 59, 22, 31, 210, 67, 183, 57, 64, 53, 202, 220, 208, 35, 0, 219, 217, 242, 61, 6, 202, 187, 187, 148, 23, 88, 48, 55, 217, 116, 77, 15, 240, 23, 205, 192, 161, 171, 131, 171, 74, 165, 232, 86, 131, 113, 248 }, new byte[] { 80, 11, 104, 212, 4, 219, 43, 208, 74, 176, 174, 188, 37, 74, 214, 223, 10, 98, 165, 243, 35, 247, 12, 210, 106, 47, 12, 115, 237, 14, 44, 157, 168, 39, 22, 200, 32, 181, 74, 168, 185, 167, 120, 12, 159, 185, 34, 230, 179, 157, 28, 220, 169, 100, 167, 41, 135, 232, 8, 166, 144, 69, 162, 54, 76, 231, 152, 62, 204, 135, 2, 178, 23, 72, 79, 228, 81, 39, 20, 81, 24, 58, 96, 210, 238, 96, 72, 233, 105, 236, 239, 49, 31, 128, 228, 147, 170, 108, 200, 84, 187, 45, 232, 214, 170, 134, 125, 248, 123, 2, 97, 200, 47, 212, 48, 100, 36, 94, 12, 73, 191, 185, 142, 130, 125, 79, 66, 92 }, 2, "user" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
