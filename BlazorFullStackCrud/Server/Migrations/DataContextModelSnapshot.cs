﻿// <auto-generated />
using System;
using BlazorFullStackCrud.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorFullStackCrud.Shared.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("BlazorFullStackCrud.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "",
                            DateOfBirth = new DateTime(2022, 3, 17, 15, 7, 1, 409, DateTimeKind.Local).AddTicks(4205),
                            Email = "user#domain.com",
                            Password = "",
                            PasswordHash = new byte[] { 11, 228, 143, 166, 30, 46, 62, 37, 88, 29, 46, 11, 237, 50, 95, 91, 35, 113, 157, 133, 136, 252, 37, 248, 154, 23, 5, 114, 45, 198, 253, 69, 128, 251, 0, 212, 27, 240, 169, 74, 206, 152, 19, 54, 190, 109, 71, 241, 251, 24, 240, 99, 230, 76, 204, 106, 200, 127, 205, 94, 219, 130, 163, 128 },
                            PasswordSalt = new byte[] { 47, 10, 56, 124, 130, 174, 153, 237, 54, 211, 138, 134, 17, 64, 169, 22, 63, 203, 36, 219, 144, 250, 26, 151, 109, 127, 97, 164, 210, 45, 85, 16, 78, 246, 33, 135, 148, 237, 65, 60, 229, 95, 170, 39, 234, 107, 84, 4, 228, 167, 242, 60, 222, 178, 160, 39, 144, 36, 157, 14, 192, 98, 53, 114, 193, 206, 218, 130, 139, 58, 40, 56, 37, 252, 231, 224, 160, 240, 195, 47, 163, 165, 228, 155, 238, 250, 65, 79, 211, 14, 251, 154, 95, 21, 231, 118, 15, 141, 224, 13, 69, 103, 23, 4, 8, 249, 163, 127, 42, 238, 129, 217, 117, 170, 207, 169, 21, 185, 151, 244, 61, 164, 71, 154, 201, 165, 68, 171 },
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            ConfirmPassword = "",
                            DateOfBirth = new DateTime(2022, 3, 17, 15, 7, 1, 409, DateTimeKind.Local).AddTicks(4212),
                            Email = "user#domain.com",
                            Password = "",
                            PasswordHash = new byte[] { 11, 228, 143, 166, 30, 46, 62, 37, 88, 29, 46, 11, 237, 50, 95, 91, 35, 113, 157, 133, 136, 252, 37, 248, 154, 23, 5, 114, 45, 198, 253, 69, 128, 251, 0, 212, 27, 240, 169, 74, 206, 152, 19, 54, 190, 109, 71, 241, 251, 24, 240, 99, 230, 76, 204, 106, 200, 127, 205, 94, 219, 130, 163, 128 },
                            PasswordSalt = new byte[] { 47, 10, 56, 124, 130, 174, 153, 237, 54, 211, 138, 134, 17, 64, 169, 22, 63, 203, 36, 219, 144, 250, 26, 151, 109, 127, 97, 164, 210, 45, 85, 16, 78, 246, 33, 135, 148, 237, 65, 60, 229, 95, 170, 39, 234, 107, 84, 4, 228, 167, 242, 60, 222, 178, 160, 39, 144, 36, 157, 14, 192, 98, 53, 114, 193, 206, 218, 130, 139, 58, 40, 56, 37, 252, 231, 224, 160, 240, 195, 47, 163, 165, 228, 155, 238, 250, 65, 79, 211, 14, 251, 154, 95, 21, 231, 118, 15, 141, 224, 13, 69, 103, 23, 4, 8, 249, 163, 127, 42, 238, 129, 217, 117, 170, 207, 169, 21, 185, 151, 244, 61, 164, 71, 154, 201, 165, 68, 171 },
                            RoleId = 2,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("BlazorFullStackCrud.Shared.User", b =>
                {
                    b.HasOne("BlazorFullStackCrud.Shared.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
