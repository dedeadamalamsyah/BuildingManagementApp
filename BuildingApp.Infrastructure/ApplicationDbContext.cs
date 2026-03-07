using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Visitor> Visitors => Set<Visitor>();
    public DbSet<Holiday> Holidays => Set<Holiday>();
}