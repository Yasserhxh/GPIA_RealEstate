using Als.Foundation.Data.Abstractions.EntityFramework;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Domain.Projects.Interfaces;
/// <summary>
/// Repository interface for managing <see cref="Unit"/> entities.
/// </summary>
public interface IUnitRepository : IBaseRepository<Unit>
{
}
