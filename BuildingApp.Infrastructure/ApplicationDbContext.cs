using BuildingApp.Application.Interfaces;
using BuildingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BuildingApp.Infrastructure;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Visitor> Visitors => Set<Visitor>();
    public DbSet<Holiday> Holidays => Set<Holiday>();
}