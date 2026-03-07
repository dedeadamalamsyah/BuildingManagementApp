using BuildingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Visitor> Visitors { get; }
    DbSet<Holiday> Holidays { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}