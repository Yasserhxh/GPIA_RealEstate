using Als.Foundation.Data.EntityFramework;
using ProjectAPI.Domain.Immeubles.Entities;
using ProjectAPI.Domain.Immeubles.Interfaces;
using ProjectAPI.Infrastructure.Context;

namespace ProjectAPI.Infrastructure.Repositories;

/// <summary>
/// Repository class for managing <see cref="Project"/> entities.
/// </summary>
public class ImmeubleRepository : BaseRepository<Immeuble>, IImmeubleRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to be used by this repository.</param>
    /// <exception cref="ArgumentNullException">Thrown when the context is null.</exception>
    public ImmeubleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}