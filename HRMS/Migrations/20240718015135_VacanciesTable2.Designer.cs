﻿// <auto-generated />
using System;
using HRMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240718015135_VacanciesTable2")]
    partial class VacanciesTable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRMS.Data.Vacancies", b =>
                {
                    b.Property<int>("Pk_VacanciesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk_VacanciesID"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fk_DesignationId")
                        .HasColumnType("int");

                    b.Property<int>("Fk_ExperienceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technology")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalPost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pk_VacanciesID");

                    b.HasIndex("Fk_DesignationId");

                    b.ToTable("Comm_Vacancies");
                });

            modelBuilder.Entity("HRMS.Models.Designation", b =>
                {
                    b.Property<int>("PK_DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK_DesignationId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_DesignationId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("HRMS.Models.Full_Forms", b =>
                {
                    b.Property<int>("PK_EfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK_EfId"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_EfId");

                    b.ToTable("Core_FullForms");
                });

            modelBuilder.Entity("HRMS.Models.Gender", b =>
                {
                    b.Property<int>("Pk_GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk_GenderId"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Pk_GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("HRMS.Data.Vacancies", b =>
                {
                    b.HasOne("HRMS.Models.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("Fk_DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Designation");
                });
#pragma warning restore 612, 618
        }
    }
}
