using AuthenticationAPI.Api.Application.Common.Models;
using AuthenticationAPI.Domain.ApplicationUser.Entities;
using AuthenticationAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AuthenticationAPI.Api.Application.Users.GetAllUsers;

/// <summary>
/// Handles the request to retrieve all users.
/// </summary>
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PaginatedResponse<GetAllUsersResponse>>
{
    private readonly ApplicationDbContext _context;

    public GetAllUsersHandler(ApplicationDbContext context)
    {
        _context = context;

    }

    /// <summary>
    /// Handles the request to retrieve all users.
    /// </summary>
    /// <param name="request">The GetAllUsersQuery request.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A list of UserResponse containing information about all users.</returns>
    public async Task<PaginatedResponse<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<User> query = _context.Users;


        if (request.RoleId != null)
        {
            query = query.Where(u => u.UserRoles.Any(r => r.Role.Id == request.RoleId));
        }

        /*if (request.AssignedBchId != null)
        {
            query = query.Where(u => u.AssignedBchId == request.AssignedBchId);
        }*/
        if (request.UserName != null)
        {
            query = query.Where(u => u.UserName == request.UserName);
        }


        int totalItems = await query.CountAsync(cancellationToken);

        query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

        var usersWithRoles = await query.Select(u => new GetAllUsersResponse
        {
            User = new UserResponse
            {
                Id = u.Id,
                UserName = u.UserName!,
                FirstName = u.FirstName,
                LastName = u.LastName,
                FirstNameAr = u.FirstNameAr,
                LastNameAr = u.LastNameAr,
               //AssignedBchId = u.AssignedBchId,
                PhoneNumber = u.PhoneNumber!,
                LockoutEnd = u.LockoutEnd
            },
            Roles = u.UserRoles.Select(u => u.Role).ToList()
        }).ToListAsync(cancellationToken);

        return new PaginatedResponse<GetAllUsersResponse>(usersWithRoles, request.PageNumber, request.PageSize, totalItems);
    }
}
