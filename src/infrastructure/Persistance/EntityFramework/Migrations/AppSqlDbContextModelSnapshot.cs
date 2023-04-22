﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.DbContext.Context;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(AppSqlDbContext))]
    partial class AppSqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Concrete.Main.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditDate");

                    b.Property<int?>("EditorId")
                        .HasColumnType("int")
                        .HasColumnName("EditorId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("Domain.Concrete.Main.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorId");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditDate");

                    b.Property<int?>("EditorId")
                        .HasColumnType("int")
                        .HasColumnName("EditorId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Domain.Concrete.Main.ExceptionNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description")
                        .UseCollation("Cyrillic_General_CI_AS");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditDate");

                    b.Property<int?>("EditorId")
                        .HasColumnType("int")
                        .HasColumnName("EditorId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Key");

                    b.Property<int>("LangId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LangId");

                    b.ToTable("ExceptionNotifications", (string)null);
                });

            modelBuilder.Entity("Domain.Concrete.Sql.Main.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorId");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditDate");

                    b.Property<int?>("EditorId")
                        .HasColumnType("int")
                        .HasColumnName("EditorId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shortname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("Domain.Concrete.Main.Employee", b =>
                {
                    b.HasOne("Domain.Concrete.Main.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.Concrete.Main.ExceptionNotification", b =>
                {
                    b.HasOne("Domain.Concrete.Sql.Main.Language", "Lang")
                        .WithMany("ExceptionNotifications")
                        .HasForeignKey("LangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lang");
                });

            modelBuilder.Entity("Domain.Concrete.Main.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Concrete.Sql.Main.Language", b =>
                {
                    b.Navigation("ExceptionNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}
