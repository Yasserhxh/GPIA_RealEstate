using Als.Foundation.Data.Abstractions.EntityFramework;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Domain.Projects.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="Project"/> entities.
    /// </summary>
    public interface IProjectRepository : IBaseRepository<Project>
    {
    }
}