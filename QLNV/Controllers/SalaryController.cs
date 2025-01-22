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

    public IActionResult Payroll(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
        if (employee is not null)
        {
            
            var details = _context.SalaryDetails.FirstOrDefault(d => d.EmployeeId == id);
            //tìm bảng lương tương ứng với nhân viên
            var salary = _context.Salarys.FirstOrDefault(x => x.Employee.Id == id);
            SalaryDetail paidRecord = new();

            DateTime now = DateTime.Now;
            (decimal tax, decimal total, decimal allowance) = (0, 0, 0);

            
            paidRecord.EmployeeId = salary.Employee.Id;

            paidRecord.BaseSalary = salary.MinimumSalary * salary.Coefficients;

            paidRecord.SocialInsurance = salary.SocialInsurance * salary.MinimumSalary / 100.00M;
            
            paidRecord.HealthInsurance = salary.HealthInsurance * salary.MinimumSalary / 100.00M;

            paidRecord.UnemploymentInsurance = salary.UnemploymentInsurance * salary.MinimumSalary / 100.00M;

            allowance = salary.MinimumSalary * salary.Allowance;
            paidRecord.Allowance = allowance;


            
            tax = salary.MinimumSalary * salary.IncomeTax / 100.00M;
            paidRecord.IncomeTax = allowance;
            paidRecord.PaidDate = DateOnly.FromDateTime(DateTime.Now);
            paidRecord.AwardPrize = 0;
            paidRecord.Fine = 0;

            total = paidRecord.BaseSalary - (paidRecord.SocialInsurance + paidRecord.HealthInsurance + paidRecord.UnemploymentInsurance) - paidRecord.IncomeTax + paidRecord.Allowance;
            paidRecord.Total = total;
            
            
            ViewBag.ok = "thanh toán thành công";
            _context.SalaryDetails.Add(paidRecord);
            
            _context.SaveChanges();

        }
        return RedirectToAction(nameof(Index));
    }


    public IActionResult PaidHistory()
    {
        var paidlist = _context.SalaryDetails.ToList();
        return View(paidlist);
    }

    public IActionResult PreviousSalary(int id)
    {
        var previous = _context.SalaryModifiHistories.Where(x => x.EmployeeId == id).ToList();
        if (previous is not null)
        {
            return View(previous);
        }

        return RedirectToAction(nameof(Index));
    }

}
