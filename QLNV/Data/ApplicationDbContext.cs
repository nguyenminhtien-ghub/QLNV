using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLNV.Models;

namespace QLNV.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<BusinessContract> BusinessContracts { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<EmployeeAward> EmployeeAwards { get; set; }

        DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        DbSet<EmployeeFined> EmployeeFineds { get; set; }
        DbSet<EmployeeEducationHistory> EmployeeEducationHistories { get; set; }
        DbSet<Salary> Salarys { get; set; }
        DbSet<SalaryDetail> SalaryDetails { get; set; }

        DbSet<SalaryModifiHistory> SalaryModifiHistories { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<EmployeeLeave> EmployeeLeaves { get; set; }

        DbSet<EmployeePosition> EmployeePositions { get; set; }
        DbSet<EmployeePositionHistory> EmployeePositionHistories { get; set; }


    }
}
