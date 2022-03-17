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
                    Username = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                values: new object[] { 1, "", new DateTime(2022, 3, 17, 15, 7, 1, 409, DateTimeKind.Local).AddTicks(4205), "user#domain.com", "", new byte[] { 11, 228, 143, 166, 30, 46, 62, 37, 88, 29, 46, 11, 237, 50, 95, 91, 35, 113, 157, 133, 136, 252, 37, 248, 154, 23, 5, 114, 45, 198, 253, 69, 128, 251, 0, 212, 27, 240, 169, 74, 206, 152, 19, 54, 190, 109, 71, 241, 251, 24, 240, 99, 230, 76, 204, 106, 200, 127, 205, 94, 219, 130, 163, 128 }, new byte[] { 47, 10, 56, 124, 130, 174, 153, 237, 54, 211, 138, 134, 17, 64, 169, 22, 63, 203, 36, 219, 144, 250, 26, 151, 109, 127, 97, 164, 210, 45, 85, 16, 78, 246, 33, 135, 148, 237, 65, 60, 229, 95, 170, 39, 234, 107, 84, 4, 228, 167, 242, 60, 222, 178, 160, 39, 144, 36, 157, 14, 192, 98, 53, 114, 193, 206, 218, 130, 139, 58, 40, 56, 37, 252, 231, 224, 160, 240, 195, 47, 163, 165, 228, 155, 238, 250, 65, 79, 211, 14, 251, 154, 95, 21, 231, 118, 15, 141, 224, 13, 69, 103, 23, 4, 8, 249, 163, 127, 42, 238, 129, 217, 117, 170, 207, 169, 21, 185, 151, 244, 61, 164, 71, 154, 201, 165, 68, 171 }, 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "DateOfBirth", "Email", "Password", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
                values: new object[] { 2, "", new DateTime(2022, 3, 17, 15, 7, 1, 409, DateTimeKind.Local).AddTicks(4212), "user#domain.com", "", new byte[] { 11, 228, 143, 166, 30, 46, 62, 37, 88, 29, 46, 11, 237, 50, 95, 91, 35, 113, 157, 133, 136, 252, 37, 248, 154, 23, 5, 114, 45, 198, 253, 69, 128, 251, 0, 212, 27, 240, 169, 74, 206, 152, 19, 54, 190, 109, 71, 241, 251, 24, 240, 99, 230, 76, 204, 106, 200, 127, 205, 94, 219, 130, 163, 128 }, new byte[] { 47, 10, 56, 124, 130, 174, 153, 237, 54, 211, 138, 134, 17, 64, 169, 22, 63, 203, 36, 219, 144, 250, 26, 151, 109, 127, 97, 164, 210, 45, 85, 16, 78, 246, 33, 135, 148, 237, 65, 60, 229, 95, 170, 39, 234, 107, 84, 4, 228, 167, 242, 60, 222, 178, 160, 39, 144, 36, 157, 14, 192, 98, 53, 114, 193, 206, 218, 130, 139, 58, 40, 56, 37, 252, 231, 224, 160, 240, 195, 47, 163, 165, 228, 155, 238, 250, 65, 79, 211, 14, 251, 154, 95, 21, 231, 118, 15, 141, 224, 13, 69, 103, 23, 4, 8, 249, 163, 127, 42, 238, 129, 217, 117, 170, 207, 169, 21, 185, 151, 244, 61, 164, 71, 154, 201, 165, 68, 171 }, 2, "user" });

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
