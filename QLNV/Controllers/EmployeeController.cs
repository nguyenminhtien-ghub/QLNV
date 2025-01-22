using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;
using QLNV.Models;

namespace QLNV.Controllers;

[Authorize(Policy = "RequireAdministratorRole")]
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var employees = _context.Employees.Where(e => e.IsActive).ToList();
        return View(employees);
    }

    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
        var contract = employee.BusinessContract;
        var salary = _context.Salarys.SingleOrDefault(s => s.Employee.Id == id);

        var detailsSalarys = _context.SalaryDetails.Where(x => x.EmployeeId == id).ToList();

        foreach (var s in detailsSalarys)
        {
            _context.SalaryDetails.Remove(s);
        }

        _context.Salarys.Remove(salary);
        _context.Employees.Remove(employee);
        _context.BusinessContracts.Remove(contract);

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
        var edus = _context.EmployeeEducations.ToList();
        ViewBag.Edus = edus;
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        var previous = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

        if (ModelState.IsValid)
        {
            if (previous is not null)
            {
                EmployeeEducationHistory eduRecord = new();
                eduRecord.EmployeeId = employee.Id;
                eduRecord.UpdateTime = DateOnly.FromDateTime(DateTime.Now);
                eduRecord.OldEducationId = previous.EductionStatus.Id;
                eduRecord.NewEducationId = employee.EductionStatus.Id;

                previous.NumberCode = employee.NumberCode;
                previous.Name = employee.Name;
                
                previous.Gender = employee.Gender;

                previous.EmployeePosition = employee.EmployeePosition;
                previous.Country = employee.Country;
                previous.AvatarImagePath = employee.AvatarImagePath;
                previous.Ethnic = employee.Ethnic;
                previous.Phone = employee.Phone;
                previous.BusinessContract = employee.BusinessContract;

                previous.DOB = employee.DOB;
                previous.IsActive = employee.IsActive;
                previous.EductionStatus = employee.EductionStatus;
                
                previous.Department = employee.Department;
                previous.CitizenNumber = employee.CitizenNumber;

                var edu = _context.EmployeeEducations.FirstOrDefault(x => x.Id.Equals(previous.Id));

                var salary = _context.Salarys.FirstOrDefault(s => s.Employee.Id.Equals(previous.Id));

                if (edu.Coefficient <= 0)
                {
                    salary.Coefficients = 1.00M;
                }
                else
                {
                    salary.Coefficients = salary.Coefficients < edu.Coefficient ? edu.Coefficient : salary.Coefficients;

                }

                _context.EmployeeEducationHistories.Add(eduRecord);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        return View(employee);
    }



}
