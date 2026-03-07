using BuildingApp.Application.Interfaces;
using BuildingApp.Application.Services;
using BuildingApp.Domain.Entities;
using Moq;
using MockQueryable.Moq;
using Microsoft.EntityFrameworkCore;

namespace BuildingApp.Tests;

public class VisitorServiceTests
{
    [Fact]
    public async Task RegisterVisitor_ShouldReturnFalse_WhenTodayIsHoliday()
    {
        var mockContext = new Mock<IApplicationDbContext>();

        var holidays = new List<Holiday> {
            new Holiday { Id = 1, Name = "Test Holiday", Date = DateTime.Today }
        };

        var mockSet = holidays.BuildMockDbSet();

        mockContext.Setup(c => c.Holidays).Returns(mockSet.Object);

        var service = new VisitorService(mockContext.Object);
        var visitor = new Visitor { FullName = "Adam", Email = "adam@test.com" };

        var result = await service.RegisterVisitor(visitor);

        Assert.False(result);
    }
}