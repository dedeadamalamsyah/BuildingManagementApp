using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingApp.Web.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _holidayService.DeleteHoliday(id);
        return RedirectToAction(nameof(Index));
    }
}