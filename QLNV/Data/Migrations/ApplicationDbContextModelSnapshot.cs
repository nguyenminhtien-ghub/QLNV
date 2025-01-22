﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLNV.Data;

#nullable disable

namespace QLNV.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QLNV.Models.BusinessContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContractNumberCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("business_contract");
                });

            modelBuilder.Entity("QLNV.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentNumberCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("QLNV.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BusinessContractId")
                        .HasColumnType("int");

                    b.Property<string>("CitizenNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EductionStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeePositionId")
                        .HasColumnType("int");

                    b.Property<string>("Ethnic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessContractId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EductionStatusId");

                    b.HasIndex("EmployeePositionId");

                    b.HasIndex("SalaryId")
                        .IsUnique();

                    b.ToTable("employee");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Prize")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_award");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Coefficient")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<string>("EducationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationStatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MajorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MajorNumberCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employee_ducation");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeEducationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("NewEducationId")
                        .HasColumnType("int");

                    b.Property<int>("OldEducationId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdateTime")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_education_history");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeFined", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fine")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_fined");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeLeave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_leave");
                });

            modelBuilder.Entity("QLNV.Models.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Coefficient")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionNumberCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employee_position");
                });

            modelBuilder.Entity("QLNV.Models.EmployeePositionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ChangeDate")
                        .HasColumnType("date");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("NewDepartment")
                        .HasColumnType("int");

                    b.Property<int>("OldDepartment")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_position_history");
                });

            modelBuilder.Entity("QLNV.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Allowance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("Coefficients")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("HealthInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("IncomeTax")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("MinimumSalary")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("SocialInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("UnemploymentInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.ToTable("salary");
                });

            modelBuilder.Entity("QLNV.Models.SalaryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Allowance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("AwardPrize")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("BaseSalary")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fine")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("HealthInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("IncomeTax")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<DateOnly>("PaidDate")
                        .HasColumnType("date");

                    b.Property<int>("SalaryId")
                        .HasColumnType("int");

                    b.Property<decimal>("SocialInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("Total")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("UnemploymentInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.HasIndex("SalaryId");

                    b.ToTable("salary_detail");
                });

            modelBuilder.Entity("QLNV.Models.SalaryModifiHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Allowance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("Coefficients")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("HealthInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("IncomeTax")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<DateOnly>("ModifiDate")
                        .HasColumnType("date");

                    b.Property<decimal>("NewSalary")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("OldSalary")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("SalaryId")
                        .HasColumnType("int");

                    b.Property<decimal>("SocialInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<decimal>("UnemploymentInsurance")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.HasIndex("SalaryId");

                    b.ToTable("salary_modifi_history");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNV.Models.Employee", b =>
                {
                    b.HasOne("QLNV.Models.BusinessContract", "BusinessContract")
                        .WithMany("Employees")
                        .HasForeignKey("BusinessContractId");

                    b.HasOne("QLNV.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("QLNV.Models.EmployeeEducation", "EductionStatus")
                        .WithMany("Employees")
                        .HasForeignKey("EductionStatusId");

                    b.HasOne("QLNV.Models.EmployeePosition", "EmployeePosition")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeePositionId");

                    b.HasOne("QLNV.Models.Salary", "Salary")
                        .WithOne("Employee")
                        .HasForeignKey("QLNV.Models.Employee", "SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessContract");

                    b.Navigation("Department");

                    b.Navigation("EductionStatus");

                    b.Navigation("EmployeePosition");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeAward", b =>
                {
                    b.HasOne("QLNV.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeEducationHistory", b =>
                {
                    b.HasOne("QLNV.Models.Employee", "Employee")
                        .WithMany("EducationHistories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeFined", b =>
                {
                    b.HasOne("QLNV.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeLeave", b =>
                {
                    b.HasOne("QLNV.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QLNV.Models.EmployeePositionHistory", b =>
                {
                    b.HasOne("QLNV.Models.Employee", "Employee")
                        .WithMany("PositionHistories")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QLNV.Models.SalaryDetail", b =>
                {
                    b.HasOne("QLNV.Models.Salary", "Salary")
                        .WithMany("SalaryDetails")
                        .HasForeignKey("SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("QLNV.Models.SalaryModifiHistory", b =>
                {
                    b.HasOne("QLNV.Models.Salary", "Salary")
                        .WithMany("SalaryModifiHistorys")
                        .HasForeignKey("SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("QLNV.Models.BusinessContract", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QLNV.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QLNV.Models.Employee", b =>
                {
                    b.Navigation("EducationHistories");

                    b.Navigation("PositionHistories");
                });

            modelBuilder.Entity("QLNV.Models.EmployeeEducation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QLNV.Models.EmployeePosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QLNV.Models.Salary", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("SalaryDetails");

                    b.Navigation("SalaryModifiHistorys");
                });
#pragma warning restore 612, 618
        }
    }
}
