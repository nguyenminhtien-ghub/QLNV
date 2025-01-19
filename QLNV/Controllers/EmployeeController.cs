using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;

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
}
