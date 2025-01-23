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

        
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeAward> EmployeeAwards { get; set; }

        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeFined> EmployeeFineds { get; set; }
        public DbSet<EmployeeEducationHistory> EmployeeEducationHistories { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<SalaryDetail> SalaryDetails { get; set; }

        public DbSet<SalaryModifiHistory> SalaryModifiHistories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }

        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<EmployeePositionHistory> EmployeePositionHistories { get; set; }


    }
}
