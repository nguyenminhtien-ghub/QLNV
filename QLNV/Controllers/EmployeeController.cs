using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var employees = _context.Employees.Where(e => e.IsActive)
            .Include(e => e.EductionStatus)
            .ToList();
        return View(employees);
    }

    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
        
        var salary = _context.Salarys.SingleOrDefault(s => s.EmployeeId == id);

        var detailsSalarys = _context.SalaryDetails.Where(x => x.EmployeeId == id).ToList();

        foreach (var s in detailsSalarys)
        {
            _context.SalaryDetails.Remove(s);
        }

        _context.Salarys.Remove(salary);
        _context.Employees.Remove(employee);
        

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.Include(e => e.Department)
            .Include(e => e.EductionStatus).FirstOrDefault(e => e.Id == id);
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
                eduRecord.OldEducationId = previous.EmployeeEducatonId;
                eduRecord.NewEducationId = employee.EmployeeEducatonId;

                previous.NumberCode = employee.NumberCode;
                previous.Name = employee.Name;
                
                previous.Gender = employee.Gender;

                previous.EmployeePositionId = employee.EmployeePositionId;
                previous.Country = employee.Country;
                previous.AvatarImagePath = employee.AvatarImagePath;
                previous.Ethnic = employee.Ethnic;
                previous.Phone = employee.Phone;
                

                previous.DOB = employee.DOB;
                previous.IsActive = employee.IsActive;
                previous.EmployeeEducatonId = employee.EmployeeEducatonId;
                
                previous.DepartmentId = employee.DepartmentId;
                previous.CitizenNumber = employee.CitizenNumber;

                var edu = _context.EmployeeEducations.FirstOrDefault(x => x.Id.Equals(previous.Id));

                var salary = _context.Salarys.FirstOrDefault(s => s.EmployeeId.Equals(previous.Id));

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

    public IActionResult Create()
    {
        var positions = _context.EmployeePositions.ToList();
        var edus = _context.EmployeeEducations.ToList();
        var departments = _context.Departments.ToList();
        ViewBag.Position = positions;
        ViewBag.Edus = edus;
        ViewBag.Department = departments;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            ViewBag.err = String.Empty;
            var isExist = _context.Employees.Any(x => x.Id == employee.Id);

            if (isExist)
            {
                ViewBag.err = "tài khoản đã tồn tại";
                
                return View(employee);
            }
            else
            {
                Salary salary = new();
                
                Employee newEmployee = new();
                newEmployee.Id = employee.Id;
                newEmployee.NumberCode = employee.NumberCode;
                newEmployee.Name = employee.Name;
                newEmployee.DOB = employee.DOB;
                newEmployee.Country = employee.Country;
                newEmployee.Gender = employee.Gender;
                newEmployee.Ethnic = employee.Ethnic;
                newEmployee.EmployeePositionId = employee.EmployeePositionId;
                newEmployee.DepartmentId = employee.DepartmentId;
                newEmployee.EmployeeEducatonId = employee.EmployeeEducatonId;
                
                
                newEmployee.IsActive = true;
               
                
                salary.EmployeeId = employee.Id;
                salary.MinimumSalary = 1150000;
                salary.SocialInsurance = 8.00M;
                salary.HealthInsurance = 1.50M;
                salary.UnemploymentInsurance = 1.00M;

                var edu = _context.EmployeeEducations.FirstOrDefault(x => x.Id.Equals(employee.EmployeeEducatonId));
                var position = _context.EmployeePositions.SingleOrDefault(p => p.Id.Equals(employee.EmployeePositionId));

                if (edu.Id.Equals(employee.EmployeeEducatonId))
                {
                    salary.Coefficients = edu.Coefficient;
                }


                if (position.Id.Equals(employee.EmployeePositionId))
                {
                    
                    salary.Allowance = position.Coefficient;
                    
                }



                
                _context.Employees.Add(newEmployee);
              

                _context.SaveChanges();
                
                salary.EmployeeId = newEmployee.Id;
                
                _context.Salarys.Add(salary);
                
                _context.SaveChanges();

                newEmployee.SalaryId = salary.Id;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }
        else
        {

            return View(employee);
        }
    }

    public IActionResult Promotion(int id)
    {
        var record = _context.EmployeePositionHistories.Where(x => x.Employee.Id == id)
            .Include(x => x.Employee).ToList();
        var deparments = _context.Departments.ToList();
        ViewBag.Department = deparments;
        return View(record);
    }

    public IActionResult Education(int id)
    {
        var record = _context.EmployeeEducationHistories.Where(x => x.EmployeeId == id)
            .Include(x => x.Employee).ToList();
        ViewBag.Edus = _context.EmployeeEducations.ToList();
        return View(record);
    }

}
