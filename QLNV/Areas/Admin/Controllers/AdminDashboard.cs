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
        return View();
    }

    
}
