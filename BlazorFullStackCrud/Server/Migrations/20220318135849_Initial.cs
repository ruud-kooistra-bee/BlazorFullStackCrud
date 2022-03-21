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
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 18, 14, 58, 49, 635, DateTimeKind.Local).AddTicks(1794), "user#domain.com", new byte[] { 5, 166, 104, 20, 180, 5, 185, 141, 65, 181, 152, 111, 204, 80, 185, 54, 223, 112, 104, 74, 192, 53, 162, 115, 13, 161, 150, 198, 160, 167, 11, 230, 99, 141, 71, 200, 124, 252, 162, 126, 4, 90, 93, 25, 111, 115, 169, 140, 179, 103, 201, 173, 116, 48, 91, 46, 175, 206, 137, 38, 121, 201, 189, 253 }, new byte[] { 232, 231, 109, 200, 172, 22, 161, 205, 218, 78, 178, 155, 151, 117, 145, 29, 56, 54, 184, 158, 186, 85, 79, 205, 246, 139, 189, 244, 50, 85, 129, 95, 25, 254, 177, 117, 119, 3, 53, 72, 226, 86, 139, 236, 223, 20, 242, 18, 172, 50, 69, 182, 130, 82, 211, 231, 150, 94, 63, 103, 232, 86, 79, 33, 3, 153, 95, 86, 131, 5, 24, 232, 199, 59, 223, 19, 130, 245, 14, 166, 219, 92, 220, 225, 48, 78, 242, 35, 30, 235, 240, 54, 244, 148, 104, 56, 209, 234, 94, 31, 250, 225, 224, 131, 246, 66, 184, 172, 15, 56, 171, 51, 133, 251, 224, 161, 205, 195, 114, 216, 74, 113, 9, 170, 188, 196, 45, 158 }, 1, "admin" },
                    { 2, new DateTime(2022, 3, 18, 14, 58, 49, 635, DateTimeKind.Local).AddTicks(1801), "user#domain.com", new byte[] { 5, 166, 104, 20, 180, 5, 185, 141, 65, 181, 152, 111, 204, 80, 185, 54, 223, 112, 104, 74, 192, 53, 162, 115, 13, 161, 150, 198, 160, 167, 11, 230, 99, 141, 71, 200, 124, 252, 162, 126, 4, 90, 93, 25, 111, 115, 169, 140, 179, 103, 201, 173, 116, 48, 91, 46, 175, 206, 137, 38, 121, 201, 189, 253 }, new byte[] { 232, 231, 109, 200, 172, 22, 161, 205, 218, 78, 178, 155, 151, 117, 145, 29, 56, 54, 184, 158, 186, 85, 79, 205, 246, 139, 189, 244, 50, 85, 129, 95, 25, 254, 177, 117, 119, 3, 53, 72, 226, 86, 139, 236, 223, 20, 242, 18, 172, 50, 69, 182, 130, 82, 211, 231, 150, 94, 63, 103, 232, 86, 79, 33, 3, 153, 95, 86, 131, 5, 24, 232, 199, 59, 223, 19, 130, 245, 14, 166, 219, 92, 220, 225, 48, 78, 242, 35, 30, 235, 240, 54, 244, 148, 104, 56, 209, 234, 94, 31, 250, 225, 224, 131, 246, 66, 184, 172, 15, 56, 171, 51, 133, 251, 224, 161, 205, 195, 114, 216, 74, 113, 9, 170, 188, 196, 45, 158 }, 2, "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
