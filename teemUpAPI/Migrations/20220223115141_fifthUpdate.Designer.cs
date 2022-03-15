﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using teemUpAPI.Data;

#nullable disable

namespace teemUpAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220223115141_fifthUpdate")]
    partial class fifthUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("teemUpAPI.Models.dutyTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("dutyTypes");
                });

            modelBuilder.Entity("teemUpAPI.Models.license", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("licenseTypesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("registrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("userTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("usersuserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("licenseTypesId");

                    b.HasIndex("usersuserId");

                    b.ToTable("license");
                });

            modelBuilder.Entity("teemUpAPI.Models.licenseTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("licenseTypes");
                });

            modelBuilder.Entity("teemUpAPI.Models.taskAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("dutyId")
                        .HasColumnType("int");

                    b.Property<int?>("dutyTypesId")
                        .HasColumnType("int");

                    b.Property<int>("lineId")
                        .HasColumnType("int");

                    b.Property<string>("progress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("taskId")
                        .HasColumnType("int");

                    b.Property<int?>("taskstaskId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int?>("usersuserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dutyTypesId");

                    b.HasIndex("taskstaskId");

                    b.HasIndex("usersuserId");

                    b.ToTable("taskAssignment");
                });

            modelBuilder.Entity("teemUpAPI.Models.Tasks", b =>
                {
                    b.Property<int>("taskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("taskId"), 1L, 1);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("definition")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("dueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("lineNum")
                        .HasColumnType("int");

                    b.HasKey("taskId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("teemUpAPI.Models.teamMembers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("teamId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("teamId");

                    b.HasIndex("userId");

                    b.ToTable("teamMembers");
                });

            modelBuilder.Entity("teemUpAPI.Models.Teams", b =>
                {
                    b.Property<int>("teamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("teamId"), 1L, 1);

                    b.Property<string>("teamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("teamId");

                    b.HasIndex("userId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("teemUpAPI.Models.Users", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("teemUpAPI.Models.license", b =>
                {
                    b.HasOne("teemUpAPI.Models.licenseTypes", "licenseTypes")
                        .WithMany()
                        .HasForeignKey("licenseTypesId");

                    b.HasOne("teemUpAPI.Models.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersuserId");

                    b.Navigation("licenseTypes");

                    b.Navigation("users");
                });

            modelBuilder.Entity("teemUpAPI.Models.taskAssignment", b =>
                {
                    b.HasOne("teemUpAPI.Models.dutyTypes", "dutyTypes")
                        .WithMany()
                        .HasForeignKey("dutyTypesId");

                    b.HasOne("teemUpAPI.Models.Tasks", "tasks")
                        .WithMany()
                        .HasForeignKey("taskstaskId");

                    b.HasOne("teemUpAPI.Models.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersuserId");

                    b.Navigation("dutyTypes");

                    b.Navigation("tasks");

                    b.Navigation("users");
                });

            modelBuilder.Entity("teemUpAPI.Models.Tasks", b =>
                {
                    b.HasOne("teemUpAPI.Models.Teams", "team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("teemUpAPI.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("team");
                });

            modelBuilder.Entity("teemUpAPI.Models.teamMembers", b =>
                {
                    b.HasOne("teemUpAPI.Models.Teams", "team")
                        .WithMany()
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("teemUpAPI.Models.Users", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("team");

                    b.Navigation("user");
                });

            modelBuilder.Entity("teemUpAPI.Models.Teams", b =>
                {
                    b.HasOne("teemUpAPI.Models.Users", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
