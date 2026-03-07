using BuildingApp.Domain.Entities;

namespace BuildingApp.Application.Interfaces;

public interface IHolidayService
{
    Task<List<Holiday>> GetAllHolidays();
    Task CreateHoliday(Holiday holiday);
    Task DeleteHoliday(int id);
}