using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNV.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateManagementScheme4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentNumberCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee_ducation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorNumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coefficient = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_ducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee_position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionNumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coefficient = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumSalary = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    HealthInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    SocialInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    UnemploymentInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    IncomeTax = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    Coefficients = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Ethnic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePositionId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    BusinessContractId = table.Column<int>(type: "int", nullable: true),
                    EductionStatusId = table.Column<int>(type: "int", nullable: true),
                    CitizenNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_business_contract_BusinessContractId",
                        column: x => x.BusinessContractId,
                        principalTable: "business_contract",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employee_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employee_employee_ducation_EductionStatusId",
                        column: x => x.EductionStatusId,
                        principalTable: "employee_ducation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employee_employee_position_EmployeePositionId",
                        column: x => x.EmployeePositionId,
                        principalTable: "employee_position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employee_salary_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salary_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployId = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    HealthInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    SocialInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    UnemploymentInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    IncomeTax = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    AwardPrize = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    Fine = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    PaidDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salary_detail_salary_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salary_modifi_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OldSalary = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    NewSalary = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    HealthInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    SocialInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    UnemploymentInsurance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    IncomeTax = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    ModifiDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Coefficients = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_modifi_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salary_modifi_history_salary_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_award",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prize = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_award", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_award_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employee_education_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    OldEducationId = table.Column<int>(type: "int", nullable: false),
                    NewEducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_education_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_education_history_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_fined",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Fine = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_fined", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_fined_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employee_leave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_leave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_leave_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employee_position_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldDepartment = table.Column<int>(type: "int", nullable: false),
                    NewDepartment = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_position_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_position_history_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_BusinessContractId",
                table: "employee",
                column: "BusinessContractId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentId",
                table: "employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_EductionStatusId",
                table: "employee",
                column: "EductionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeePositionId",
                table: "employee",
                column: "EmployeePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_SalaryId",
                table: "employee",
                column: "SalaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_award_EmployeeId",
                table: "employee_award",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_education_history_EmployeeId",
                table: "employee_education_history",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_fined_EmployeeId",
                table: "employee_fined",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_leave_EmployeeId",
                table: "employee_leave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_position_history_EmployeeId",
                table: "employee_position_history",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_salary_detail_SalaryId",
                table: "salary_detail",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_salary_modifi_history_SalaryId",
                table: "salary_modifi_history",
                column: "SalaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_award");

            migrationBuilder.DropTable(
                name: "employee_education_history");

            migrationBuilder.DropTable(
                name: "employee_fined");

            migrationBuilder.DropTable(
                name: "employee_leave");

            migrationBuilder.DropTable(
                name: "employee_position_history");

            migrationBuilder.DropTable(
                name: "salary_detail");

            migrationBuilder.DropTable(
                name: "salary_modifi_history");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "business_contract");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employee_ducation");

            migrationBuilder.DropTable(
                name: "employee_position");

            migrationBuilder.DropTable(
                name: "salary");
        }
    }
}
