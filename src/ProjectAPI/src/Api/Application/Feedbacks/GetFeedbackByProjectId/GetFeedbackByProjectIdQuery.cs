using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Feedbacks.GetFeedbackByProjectId
{
    /// <summary>
    /// Query to retrieve feedback by Project ID.
    /// </summary>
    public class GetFeedbackByProjectIdQuery : IRequest<PaginatedResponse<FeedbackDetailsResponse>>
    {
        /// <summary>
        /// Gets or sets the Project ID for which feedback is to be retrieved.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}