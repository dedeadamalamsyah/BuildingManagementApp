using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Application.Services;

public class VisitorService : IVisitorService
{
    private readonly IApplicationDbContext _context;
    public VisitorService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterVisitor(Visitor visitor)
    {
        var isHoliday = await _context.Holidays
            .AnyAsync(h => h.Date.Date == DateTime.Today.Date);

        if (isHoliday) return false;

        _context.Visitors.Add(visitor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Visitor>> GetAllVisitors(DateTime? from, DateTime? to)
    {
        var query = _context.Visitors.AsQueryable();

        if (from.HasValue)
        {
            query = query.Where(v => v.RegistrationDate.Date >= from.Value.Date);
        }

        if (to.HasValue)
        {
            query = query.Where(v => v.RegistrationDate.Date <= to.Value.Date);
        }

        return await query.OrderByDescending(v => v.RegistrationDate).ToListAsync();
    }

    public async Task DeleteRegistration(int id)
    {
        var visitor = await _context.Visitors.FindAsync(id);
        if (visitor != null)
        {
            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }
    }
}