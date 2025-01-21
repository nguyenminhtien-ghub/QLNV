using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;
using QLNV.Models;

namespace QLNV.Controllers;

[Authorize(Policy = "RequireAdministratorRole")]
public class SalaryController : Controller
{
    private readonly ApplicationDbContext _context;

    public SalaryController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var salarys = _context.Salarys.ToList();
        return View(salarys);
    }

    public IActionResult Edit(int id)
    {
        var salary = _context.Salarys.FirstOrDefault(s => s.Employee.Id == id);
        return View(salary);
    }

    [HttpPost]
    public IActionResult Edit(Salary salary, SalaryModifiHistory history)
    {
        var newSalary = _context.Salarys.FirstOrDefault(s => s.Employee.Id == salary.Employee.Id);
        if (newSalary != null)
        {
            
            if (decimal.Parse(history.NewSalary.ToString()) != 0)
            {
                newSalary.MinimumSalary = history.NewSalary;
            }

            newSalary.SocialInsurance = salary.SocialInsurance;
            newSalary.HealthInsurance = salary.HealthInsurance;
            newSalary.UnemploymentInsurance = salary.UnemploymentInsurance;
            
            newSalary.IncomeTax = salary.IncomeTax;
            newSalary.Coefficients = salary.Coefficients;

            
            SalaryModifiHistory modifiRecord = new();
            modifiRecord.ModifiDate = DateOnly.FromDateTime(DateTime.Now);
            modifiRecord.EmployeeId = salary.Employee.Id;
            modifiRecord.OldSalary = salary.MinimumSalary;
            modifiRecord.NewSalary = history.NewSalary;
            modifiRecord.SocialInsurance = salary.SocialInsurance;
            modifiRecord.HealthInsurance = salary.HealthInsurance;
            modifiRecord.UnemploymentInsurance = salary.UnemploymentInsurance;
            
            modifiRecord.IncomeTax = salary.IncomeTax;
            modifiRecord.Coefficients = salary.Coefficients;

            _context.SalaryModifiHistories.Add(modifiRecord);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

}
