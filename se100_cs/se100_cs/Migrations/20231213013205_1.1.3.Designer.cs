﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using se100_cs.Model;

#nullable disable

namespace se100_cs.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231213013205_1.1.3")]
    partial class _113
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("se100_cs.Model.SqlATDDetail", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<long>("attendanceID")
                        .HasColumnType("bigint");

                    b.Property<long>("employeeID")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("time")
                        .HasColumnType("time without time zone");

                    b.HasKey("ID");

                    b.HasIndex("attendanceID");

                    b.HasIndex("employeeID");

                    b.ToTable("tb_attendance_detail");
                });

            modelBuilder.Entity("se100_cs.Model.SqlAttendance", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<int>("day")
                        .HasColumnType("integer");

                    b.Property<int>("month")
                        .HasColumnType("integer");

                    b.Property<int>("year")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("tb_attendance");
                });

            modelBuilder.Entity("se100_cs.Model.SqlDepartment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("tb_department");
                });

            modelBuilder.Entity("se100_cs.Model.SqlEmployee", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("birth_day")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("cmnd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("departmentID")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("gender")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("positionID")
                        .HasColumnType("bigint");

                    b.Property<int?>("role")
                        .HasColumnType("integer");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("departmentID");

                    b.HasIndex("positionID");

                    b.ToTable("tb_employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPayroll", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<long?>("employeeID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("receive_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("salary")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("employeeID");

                    b.ToTable("tb_payroll");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPosition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("departmentID")
                        .HasColumnType("bigint");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("salary_coeffcient")
                        .HasColumnType("bigint");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("departmentID");

                    b.ToTable("tb_position");
                });

            modelBuilder.Entity("se100_cs.Model.SqlRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("tb_role");
                });

            modelBuilder.Entity("se100_cs.Model.SqlSetting", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("company_code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("payment_date")
                        .HasColumnType("integer");

                    b.Property<int>("salary_per_coef")
                        .HasColumnType("integer");

                    b.Property<int>("start_time_hour")
                        .HasColumnType("integer");

                    b.Property<int>("start_time_minute")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("tb_setting");
                });

            modelBuilder.Entity("se100_cs.Model.SqlATDDetail", b =>
                {
                    b.HasOne("se100_cs.Model.SqlAttendance", "attendance")
                        .WithMany("list_attendance")
                        .HasForeignKey("attendanceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("se100_cs.Model.SqlEmployee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("attendance");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlEmployee", b =>
                {
                    b.HasOne("se100_cs.Model.SqlDepartment", "department")
                        .WithMany("employees")
                        .HasForeignKey("departmentID");

                    b.HasOne("se100_cs.Model.SqlPosition", "position")
                        .WithMany("employees")
                        .HasForeignKey("positionID");

                    b.Navigation("department");

                    b.Navigation("position");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPayroll", b =>
                {
                    b.HasOne("se100_cs.Model.SqlEmployee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeID");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPosition", b =>
                {
                    b.HasOne("se100_cs.Model.SqlDepartment", "department")
                        .WithMany()
                        .HasForeignKey("departmentID");

                    b.Navigation("department");
                });

            modelBuilder.Entity("se100_cs.Model.SqlAttendance", b =>
                {
                    b.Navigation("list_attendance");
                });

            modelBuilder.Entity("se100_cs.Model.SqlDepartment", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPosition", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
