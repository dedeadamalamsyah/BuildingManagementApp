using BuildingApp.Application.Interfaces;
using BuildingApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly IApplicationDbContext _context;

    public HomeController(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var isHoliday = await _context.Holidays.AnyAsync(h => h.Date.Date == DateTime.Today);
        ViewBag.IsHoliday = isHoliday;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
