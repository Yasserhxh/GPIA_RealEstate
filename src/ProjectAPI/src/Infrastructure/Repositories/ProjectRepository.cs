using Als.Foundation.Data.EntityFramework;
using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Projects.Interfaces;
using ProjectAPI.Infrastructure.Context;

namespace ProjectAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for managing <see cref="Project"/> entities.
    /// </summary>
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by this repository.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null.</exception>
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}