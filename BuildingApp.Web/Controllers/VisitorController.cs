using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingApp.Web.Controllers;

public class VisitorController : Controller
{
    private readonly IVisitorService _visitorService;

    public VisitorController(IVisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Visitor visitor)
    {
        if (!ModelState.IsValid) return View(visitor);

        var success = await _visitorService.RegisterVisitor(visitor);

        if (success)
        {
            TempData["SuccessMessage"] = "Registration Successful! Automatically Approved.";
            return RedirectToAction(nameof(Register));
        }
        else
        {
            ModelState.AddModelError("", "Sorry, registration is disabled during holidays.");
            return View(visitor);
        }
    }
}