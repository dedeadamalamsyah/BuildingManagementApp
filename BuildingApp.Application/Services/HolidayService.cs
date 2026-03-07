using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Application.Services;

public class HolidayService : IHolidayService
{
    private readonly IApplicationDbContext _context;

    public HolidayService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Holiday>> GetAllHolidays()
    {
        return await _context.Holidays.OrderByDescending(h => h.Date).ToListAsync();
    }

    public async Task CreateHoliday(Holiday holiday)
    {
        _context.Holidays.Add(holiday);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHoliday(int id)
    {
        var holiday = await _context.Holidays.FindAsync(id);
        if (holiday != null)
        {
            _context.Holidays.Remove(holiday);
            await _context.SaveChangesAsync();
        }
    }
}