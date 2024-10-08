namespace AuthenticationAPI.Api.Application.Common.Models;

/// <summary>
/// Represents the response model for user-related operations.
/// </summary>
public record UserResponse
{
    /// <summary>
    /// Gets or sets the user's Id.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Gets or sets the user's username.
    /// </summary>
    public required string UserName { get; init; }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public required string FirstName { get; init; }

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public required string LastName { get; init; }

    /// <summary>
    /// Gets or sets the user's first name in Arabic.
    /// </summary>
    public string FirstNameAr { get; init; } = default!;

    /// <summary>
    /// Gets or sets the user's last name in Arabic.
    /// </summary>
    public string LastNameAr { get; init; } = default!;

    /// <summary>
    /// Gets or sets the ID of the assigned BCH (Business Center Hub).
    /// </summary>
    public int? AssignedBchId { get; init; }

    /// <summary>
    /// Gets or sets the list of BCH IDs the user is responsible for.
    /// </summary>
    public IEnumerable<int> ResponsibleBchIds { get; init; } = [];

    /// <summary>
    /// Gets or sets the user's phone number.
    /// </summary>
    public required string PhoneNumber { get; init; }

    /// <summary>
    /// Gets or sets the user's assignment details.
    /// </summary>
    public UserAssignmentDto? UserAssignment { get; init; }

    ///<summary>
    ///Gets or sets the date and time when the user's lockout period ends, if any.
    ///</summary>
    public DateTimeOffset? LockoutEnd { get; set; }
}

