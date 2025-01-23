using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;

namespace QLNV.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "RequireAdministratorRole")]
public class AdminDashboard : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminDashboard(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var employeesCount = _context.Employees.Where(e => e.IsActive).Count();
        ViewBag.EmployeesCount = employeesCount;
        var salarys = _context.Salarys.ToList();
        ViewBag.SalariesCount = salarys.Count();

        var departmentCount = _context.Departments.Count();
        ViewBag.DepartmentCount = departmentCount;

        var awardCount = _context.EmployeeAwards.Count();
        ViewBag.AwardCount = awardCount;

        var total = 0.0M;

        foreach (var item in salarys)
        {
            (decimal tax, decimal allowance, decimal baseSalary, decimal si, decimal hi, decimal ui) = (0, 0, 0, 0, 0, 0);

           
            baseSalary = item.MinimumSalary * item.Coefficients;

            
            si = item.SocialInsurance * item.MinimumSalary / 100.00M;

          
            hi = item.HealthInsurance * item.MinimumSalary / 100.00M;

           
            ui = item.UnemploymentInsurance * item.MinimumSalary / 100.00M;


           
            allowance = item.MinimumSalary * item.Allowance;

            
            tax = item.MinimumSalary * item.IncomeTax / 100.00M;

            total += + baseSalary - (si + hi + ui) - tax + allowance;

        }

        ViewBag.Total = total;

        return View();
    }

    
}
