using Als.Foundation.Data.Abstractions.EntityFramework;
using AuthenticationAPI.Domain.ApplicationUser.Entities;

namespace AuthenticationAPI.Domain.ApplicationUser.Interfaces;

public interface IPerformanceIndicatorRepository : IBaseRepository<PerformanceIndicator>
{
}
