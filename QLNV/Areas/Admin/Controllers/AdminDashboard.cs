using Microsoft.AspNetCore.Mvc;

namespace QLNV.Areas.Admin.Controllers
{
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
