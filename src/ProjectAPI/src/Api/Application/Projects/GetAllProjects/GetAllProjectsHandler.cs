using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.GetAllProjects;

/// <summary>
/// Handler for getting all projects.
/// </summary>
public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, PaginatedResponse<ProjectResponse>>
{
    private readonly IProjectRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllProjectsHandler"/> class.
    /// </summary>
    /// <param name="repository">The project repository to access project data.</param>
    public GetAllProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the query to get all projects.
    /// </summary>
    /// <param name="request">The query containing pagination and filtering details.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A paginated response containing the projects.</returns>
    public async Task<PaginatedResponse<ProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.Find(
            p => (string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name)) &&
                 (string.IsNullOrEmpty(request.Location) || p.Location.Contains(request.Location)) &&
                 (request.MinPrice == null || p.MinPrice >= request.MinPrice) &&
                 (request.MaxPrice == null || p.MaxPrice <= request.MaxPrice) &&
                 (request.Type == null || p.Type == request.Type.ToString()),
            null
        );

        var totalItems = projects.Count();
        var paginatedData = projects
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                Type = Enum.Parse<PropertyType>(p.Type),
                MinPrice = p.MinPrice,
                MaxPrice = p.MaxPrice,
                Status = Enum.Parse<ProjectStatus>(p.Status),
                Images = p.Images,
                Description = p.Description,
                Latitude = p.Latitude,
                Longitude = p.Longitude
            });

        return new PaginatedResponse<ProjectResponse>(paginatedData, request.PageNumber, request.PageSize, totalItems);
    }
}