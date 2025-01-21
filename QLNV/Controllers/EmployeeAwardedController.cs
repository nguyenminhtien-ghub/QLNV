using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;
using QLNV.Models;

namespace QLNV.Controllers;

[Authorize(Policy = "RequireAdministratorRole")]
public class EmployeeAwardedController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeAwardedController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var awards = _context.EmployeeAwards.ToList();
        return View(awards);
    }

    public IActionResult Create()
    {
        var employees = _context.Employees.ToList();
        ViewBag.Employees = (List<Employee>)employees;
        return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeAward award)
    {
        _context.EmployeeAwards.Add(award);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
