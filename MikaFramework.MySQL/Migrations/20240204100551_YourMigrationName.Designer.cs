﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MikaFramework.MySQL.Data;

#nullable disable

namespace MikaFramework.MySQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240204100551_YourMigrationName")]
    partial class YourMigrationName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MikaFramework.MySQL.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MikaFramework.MySQL.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StartWorkYear")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MikaFramework.MySQL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumOfActions")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MikaFramework.MySQL.Models.Employee", b =>
                {
                    b.HasOne("MikaFramework.MySQL.Models.Department", "Department")
                        .WithOne("Manager")
                        .HasForeignKey("MikaFramework.MySQL.Models.Employee", "DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MikaFramework.MySQL.Models.Department", b =>
                {
                    b.Navigation("Manager")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}