using BuildingApp.Domain.Entities;

namespace BuildingApp.Application.Interfaces;

public interface IVisitorService
{
    Task<bool> RegisterVisitor(Visitor visitor);
    Task<List<Visitor>> GetAllVisitors(DateTime? from, DateTime? to);
    Task DeleteRegistration(int id);
}