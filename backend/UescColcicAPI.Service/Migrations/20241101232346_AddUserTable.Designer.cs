﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UescColcicAPI.Services.BD;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241101232346_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("UescColcicAPI.Core.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserID_FK")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProfessorId");

                    b.HasIndex("UserID_FK")
                        .IsUnique();

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Registration")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserID_FK")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId");

                    b.HasIndex("UserID_FK")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student_Skill", b =>
                {
                    b.Property<int>("SkillId_FK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId_FK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("SkillId_FK", "StudentId_FK");

                    b.ToTable("Student_Skills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Professor", b =>
                {
                    b.HasOne("UescColcicAPI.Core.User", "user")
                        .WithOne("Professor")
                        .HasForeignKey("UescColcicAPI.Core.Professor", "UserID_FK");

                    b.Navigation("user");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Project", b =>
                {
                    b.HasOne("UescColcicAPI.Core.Professor", null)
                        .WithMany("Projects")
                        .HasForeignKey("ProfessorId");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.HasOne("UescColcicAPI.Core.User", "user")
                        .WithOne("Student")
                        .HasForeignKey("UescColcicAPI.Core.Student", "UserID_FK");

                    b.Navigation("user");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Professor", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("UescColcicAPI.Core.User", b =>
                {
                    b.Navigation("Professor");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
