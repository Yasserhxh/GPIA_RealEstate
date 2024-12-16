using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.FeedBacks.Entities;
using ProjectAPI.Domain.FeedBacks.Interfaces;
using System.Linq.Expressions;

namespace ProjectAPI.Api.Application.Feedbacks.GetFeedBackByUserId;

/// <summary>
/// Handler for retrieving feedback by User ID.
/// </summary>
public class GetFeedbackByUserIdHandler : IRequestHandler<GetFeedbackByUserIdQuery, PaginatedResponse<FeedbackDetailsResponse>>
{
    private readonly IFeedbackRepository _feedbackRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetFeedbackByUserIdHandler"/> class.
    /// </summary>
    /// <param name="feedbackRepository">The feedback repository used to retrieve feedback information.</param>
    public GetFeedbackByUserIdHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    /// <summary>
    /// Handles the request to retrieve feedback for a specific user by User ID.
    /// </summary>
    /// <param name="request">The request containing the User ID, page number, and page size.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A <see cref="PaginatedResponse{T}"/> containing a list of feedback details for the specified user.</returns>
    public async Task<PaginatedResponse<FeedbackDetailsResponse>> Handle(GetFeedbackByUserIdQuery request, CancellationToken cancellationToken)
    {
        // Define related entities to include in the feedback query
        var includes = new Expression<Func<Feedback, object>>[]
        {
            f => f.User,
            f => f.FeedBack_Project
        };

        // Retrieve feedback by user ID
        var feedback = (await _feedbackRepository.Find(f => f.UserId == request.UserId.ToString(), includes)).ToList();

        var totalItems = feedback.Count;
        var paginatedData = feedback
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new FeedbackDetailsResponse
            {
                FeedbackId = p.Id,
                User = new UserDto
                {
                    Id = p.User.Id,
                    UserName = p.User.UserName!,
                    Email = p.User.Email!
                },
                Project = p.FeedBack_Project != null ? new ProjectResponse
                {
                    Id = p.FeedBack_Project.Id,
                    Name = p.FeedBack_Project.Name,
                    Location = p.FeedBack_Project.Location,
                    Type = p.FeedBack_Project.Type ?? string.Empty,
                    MinPrice = p.FeedBack_Project.MinPrice,
                    MaxPrice = p.FeedBack_Project.MaxPrice
                } : null,
                Rating = p.Rating,
                Comments = p.Comments,
                Attachments = p.Attachments,
                CreatedAt = p.CreatedAt
            });

        // Return paginated feedback response
        return new PaginatedResponse<FeedbackDetailsResponse>(paginatedData, request.PageNumber, request.PageSize, totalItems);
    }
}
