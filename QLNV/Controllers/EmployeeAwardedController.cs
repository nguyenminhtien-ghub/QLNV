using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNV.Data;

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
}
