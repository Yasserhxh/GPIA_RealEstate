using Als.Foundation.Data.EntityFramework;
using AuthenticationAPI.Domain.ApplicationUser.Entities;
using AuthenticationAPI.Domain.ApplicationUser.Interfaces;
using AuthenticationAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.Infrastructure.Repositories;

public class PerformanceIndicatorRepository : BaseRepository<PerformanceIndicator>, IPerformanceIndicatorRepository
{
    private readonly ApplicationDbContext _context;

    public PerformanceIndicatorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
