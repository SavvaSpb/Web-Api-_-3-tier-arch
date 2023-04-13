﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230404123313_Test_Constraints")]
    partial class Test_Constraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course_type_name")
                        .HasColumnOrder(1);

                    b.Property<int>("InstituteId")
                        .HasColumnType("int")
                        .HasColumnName("institute_id")
                        .HasColumnOrder(2);

                    b.Property<int>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary")
                        .HasColumnOrder(4);

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id")
                        .HasColumnOrder(3);

                    b.HasKey("CourseId");

                    b.HasIndex("InstituteId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DAL.Entities.Institute", b =>
                {
                    b.Property<int>("InstituteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("institute_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstituteId"));

                    b.Property<string>("InstituteTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("institute_type_name")
                        .HasColumnOrder(1);

                    b.HasKey("InstituteId");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("DAL.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday")
                        .HasColumnOrder(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email")
                        .HasColumnOrder(6);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name")
                        .HasColumnOrder(2);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone")
                        .HasColumnOrder(5);

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DAL.Entities.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_course_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCourseId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id")
                        .HasColumnOrder(2);

                    b.Property<int>("StudentGrade")
                        .HasColumnType("int")
                        .HasColumnName("student_grade")
                        .HasColumnOrder(3);

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasColumnOrder(1);

                    b.HasKey("StudentCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday")
                        .HasColumnOrder(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email")
                        .HasColumnOrder(6);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name")
                        .HasColumnOrder(2);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone")
                        .HasColumnOrder(5);

                    b.HasKey("TeacherId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Teacher", t =>
                        {
                            t.HasCheckConstraint("Phone", "Phone like '+374%'");
                        });
                });

            modelBuilder.Entity("DAL.Entities.UserAccount", b =>
                {
                    b.Property<int>("UserAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_account_id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email")
                        .HasColumnOrder(1);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password")
                        .HasColumnOrder(2);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone")
                        .HasColumnOrder(3);

                    b.HasKey("UserAccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.HasOne("DAL.Entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DAL.Entities.StudentCourse", b =>
                {
                    b.HasOne("DAL.Entities.Course", "Course")
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Student", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("DAL.Entities.Student", b =>
                {
                    b.Navigation("StudentCourse");
                });
#pragma warning restore 612, 618
        }
    }
}
