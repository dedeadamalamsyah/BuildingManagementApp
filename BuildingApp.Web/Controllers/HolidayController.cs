using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingApp.Web.Controllers;

[Authorize(Roles = "Admin")]
public class HolidayController : Controller
{
    private readonly IHolidayService _holidayService;

    public HolidayController(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    public async Task<IActionResult> Index()
    {
        var holidays = await _holidayService.GetAllHolidays();
        return View(holidays);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Holiday holiday)
    {
        if (ModelState.IsValid)
        {
            await _holidayService.CreateHoliday(holiday);
            return RedirectToAction(nameof(Index));
        }
        return View("Index", await _holidayService.GetAllHolidays());
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var holiday = await _holidayService.GetHolidayById(id);
        if (holiday == null) return NotFound();
        return View(holiday);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Holiday holiday)
    {
        if (ModelState.IsValid)
        {
            await _holidayService.UpdateHoliday(holiday);
            return RedirectToAction(nameof(Index));
        }
        return View(holiday);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _holidayService.DeleteHoliday(id);
        return RedirectToAction(nameof(Index));
    }
}