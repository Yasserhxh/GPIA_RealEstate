using AuthenticationAPI.Api.Application.Common.Models;

namespace AuthenticationAPI.Api.Application.Users.GetAllUsers;

/// <summary>
/// Represents a query for retrieving all users.
/// </summary>
public record GetAllUsersQuery : IRequest<PaginatedResponse<GetAllUsersResponse>>
{
    /// <summary>
    /// Gets or sets the page number for pagination.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the page size for pagination.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the role ID to filter users by role.
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// Gets or sets the business unit ID to filter users by assigned business unit.
    /// </summary>
    public int? AssignedBchId { get; set; }

    /// <summary>
    /// Gets or sets the username to filter users by username.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllUsersQuery"/> class.
    /// </summary>
    /// <param name="roleId">The role ID to filter users by role.</param>
    /// <param name="assignedBchId">The business unit ID to filter users by assigned business unit.</param>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The page size for pagination.</param>
    /// <param name="userName">The username to filter users by username.</param>
    public GetAllUsersQuery(string? roleId, int? assignedBchId, int pageNumber, int pageSize, string? userName)
    {
        RoleId = roleId;
        AssignedBchId = assignedBchId;
        PageNumber = pageNumber;
        PageSize = pageSize;
        UserName = userName;
    }
}
