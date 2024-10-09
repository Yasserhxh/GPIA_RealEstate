using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Feedbacks.GetFeedBackByUserId;
/// <summary>
/// Query to retrieve feedback by User ID.
/// </summary>
public class GetFeedbackByUserIdQuery : IRequest<PaginatedResponse<FeedbackDetailsResponse>>
{
    /// <summary>
    /// Gets or sets the User ID for which feedback is to be retrieved.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The current page number.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// The number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 10;
}
