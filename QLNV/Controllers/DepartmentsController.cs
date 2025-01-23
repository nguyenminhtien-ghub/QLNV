using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNV.Data;
using QLNV.Models;

namespace QLNV.Controllers;

[Authorize(Policy = "RequireAdministratorRole")]
public class DepartmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Departments
    public async Task<IActionResult> Index()
    {
        return View(await _context.Departments.ToListAsync());
    }

    // GET: Departments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (department == null)
        {
            return NotFound();
        }
        var departmentName = department.Name;
        ViewBag.DepartmentName = departmentName;
        ViewBag.Id = id;
        var employees = _context.Employees.Where(e => e.DepartmentId == id);

        return View(employees);
    }

    // GET: Departments/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Departments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,DepartmentNumberCode,Name,Location,Phone")] Department department)
    {
        if (_context.Departments.Any(x => x.Id == department.Id))
        {
            ViewBag.err = "mã phòng ban đã tồn tại ";
            return View(department);
        }

        if (ModelState.IsValid)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: Departments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments.FindAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: Departments/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentNumberCode,Name,Location,Phone")] Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }


    public IActionResult TransferEmployee(int employeeId)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);

        if (employee is null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    [HttpPost]
    public IActionResult TransferEmployee(Employee employee, EmployeePositionHistory history) 
    {
        var transferredEmployee = _context.Employees.Where(n => n.Id == employee.Id).FirstOrDefault();

        transferredEmployee.Id = employee.Id;
        transferredEmployee.NumberCode = employee.NumberCode;
        transferredEmployee.Name = employee.Name;
        transferredEmployee.EmployeePositionId = employee.EmployeePositionId;
        transferredEmployee.DepartmentId = history.NewDepartment;

        
        transferredEmployee.Gender = employee.Gender;
        transferredEmployee.Country = employee.Country;
        transferredEmployee.AvatarImagePath = employee.AvatarImagePath;
        transferredEmployee.Ethnic = employee.Ethnic;
        transferredEmployee.Phone = employee.Phone;
       
        transferredEmployee.DOB = employee.DOB;
        transferredEmployee.IsActive = employee.IsActive;
        transferredEmployee.EmployeeEducatonId = employee.EmployeeEducatonId;
       
        transferredEmployee.CitizenNumber = employee.CitizenNumber;

       
        EmployeePositionHistory transfer = new();
        transfer.Employee = _context.Employees.Find(employee.Id);

        transfer.ChangeDate = DateOnly.FromDateTime(DateTime.Now);
        transfer.OldDepartment = employee.DepartmentId; 

        transfer.NewDepartment = history.NewDepartment;
        transfer.Detail = history.Detail;
        
        var salary = _context.Salarys.SingleOrDefault(e => e.Employee.Id.Equals(employee.Id));
        var position = _context.EmployeePositions.SingleOrDefault(e => e.Id.Equals(employee.EmployeePositionId));

        salary.Allowance = position.Coefficient;

        _context.EmployeePositionHistories.Add(transfer);
        ViewBag.Positions = _context.EmployeePositions.ToList();
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.Historys = _context.EmployeePositionHistories.ToList();

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    // GET: Departments/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);


        if (department is null)
        {
            return NotFound();
        }

        var employees = department.Employees.ToList();
 
        
        foreach (var e in employees)
        {

            _context.Employees.Remove(e);
            
        }
            
        
        _context.Departments.Remove(department);
        _context.SaveChanges();

        
        return RedirectToAction(nameof(Index));
    }

    // POST: Departments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult EditAllowance()
    {
        var positions = _context.EmployeePositions.ToList();
        return View(positions);
    }

    [HttpPost]
    public IActionResult EditAllowance(EmployeePosition employeePosition, int id, IFormCollection form)
    {
        var position = _context.EmployeePositions.Find(id);
        position.Coefficient = decimal.Parse(form["Coefficient"].ToString() ?? "0");

        _context.SaveChanges();
        return RedirectToAction(nameof(EditAllowance));
    }




    private bool DepartmentExists(int id)
    {
        return _context.Departments.Any(e => e.Id == id);
    }
}
