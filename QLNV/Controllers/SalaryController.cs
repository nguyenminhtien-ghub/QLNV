﻿using Microsoft.AspNetCore.Mvc;
using QLNV.Data;

namespace QLNV.Controllers;

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
}
