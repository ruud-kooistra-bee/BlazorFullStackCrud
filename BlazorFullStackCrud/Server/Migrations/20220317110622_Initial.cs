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
                values: new object[] { 1, "", new DateTime(2022, 3, 17, 12, 6, 21, 989, DateTimeKind.Local).AddTicks(3624), "user#domain.com", "", new byte[] { 214, 145, 3, 188, 68, 77, 87, 28, 121, 178, 154, 7, 171, 92, 6, 192, 231, 219, 176, 133, 21, 82, 127, 174, 198, 172, 111, 78, 33, 11, 101, 211, 45, 101, 130, 88, 148, 81, 120, 231, 108, 79, 252, 203, 160, 253, 15, 0, 41, 218, 141, 67, 150, 114, 70, 184, 74, 75, 125, 137, 143, 136, 191, 47 }, new byte[] { 70, 254, 99, 248, 222, 85, 43, 179, 125, 196, 31, 8, 241, 119, 176, 198, 64, 113, 67, 136, 86, 19, 31, 174, 147, 240, 205, 22, 161, 49, 17, 241, 127, 167, 145, 113, 106, 204, 216, 122, 198, 162, 52, 11, 55, 170, 158, 31, 76, 174, 182, 45, 117, 168, 24, 139, 207, 115, 177, 225, 124, 215, 16, 232, 191, 234, 157, 166, 160, 154, 62, 115, 205, 114, 116, 54, 139, 114, 81, 141, 195, 62, 86, 238, 198, 150, 26, 32, 131, 55, 238, 101, 212, 94, 249, 229, 241, 105, 136, 102, 28, 252, 30, 154, 73, 162, 21, 235, 251, 166, 172, 52, 202, 248, 178, 88, 33, 28, 67, 26, 83, 30, 67, 205, 98, 163, 12, 21 }, 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "DateOfBirth", "Email", "Password", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
                values: new object[] { 2, "", new DateTime(2022, 3, 17, 12, 6, 21, 989, DateTimeKind.Local).AddTicks(3632), "user#domain.com", "", new byte[] { 214, 145, 3, 188, 68, 77, 87, 28, 121, 178, 154, 7, 171, 92, 6, 192, 231, 219, 176, 133, 21, 82, 127, 174, 198, 172, 111, 78, 33, 11, 101, 211, 45, 101, 130, 88, 148, 81, 120, 231, 108, 79, 252, 203, 160, 253, 15, 0, 41, 218, 141, 67, 150, 114, 70, 184, 74, 75, 125, 137, 143, 136, 191, 47 }, new byte[] { 70, 254, 99, 248, 222, 85, 43, 179, 125, 196, 31, 8, 241, 119, 176, 198, 64, 113, 67, 136, 86, 19, 31, 174, 147, 240, 205, 22, 161, 49, 17, 241, 127, 167, 145, 113, 106, 204, 216, 122, 198, 162, 52, 11, 55, 170, 158, 31, 76, 174, 182, 45, 117, 168, 24, 139, 207, 115, 177, 225, 124, 215, 16, 232, 191, 234, 157, 166, 160, 154, 62, 115, 205, 114, 116, 54, 139, 114, 81, 141, 195, 62, 86, 238, 198, 150, 26, 32, 131, 55, 238, 101, 212, 94, 249, 229, 241, 105, 136, 102, 28, 252, 30, 154, 73, 162, 21, 235, 251, 166, 172, 52, 202, 248, 178, 88, 33, 28, 67, 26, 83, 30, 67, 205, 98, 163, 12, 21 }, 2, "user" });

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
