using BuildingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingApp.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IVisitorService _visitorService;

    public AdminController(IVisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    public async Task<IActionResult> Visitors(DateTime? fromDate, DateTime? toDate)
    {
        var visitors = await _visitorService.GetAllVisitors(fromDate, toDate);

        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

        return View(visitors);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteVisitor(int id)
    {
        await _visitorService.DeleteRegistration(id);
        return RedirectToAction(nameof(Visitors));
    }
}