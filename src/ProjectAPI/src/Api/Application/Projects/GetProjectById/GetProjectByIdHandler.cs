using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.GetProjectById;

/// <summary>
/// Handler for the <see cref="GetProjectByIdQuery"/>.
/// </summary>
public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectResponse>
{
    private readonly IProjectRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProjectByIdHandler"/> class.
    /// </summary>
    /// <param name="repository">The project repository.</param>
    public GetProjectByIdHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the request to get a project by its ID.
    /// </summary>
    /// <param name="request">The request containing the project ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response containing the project details.</returns>
    public async Task<ProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIDAsync(request.Id);

        if (project == null)
        {
            throw new NotFoundException($"Project with ID {request.Id} not found.");
        }

        return new ProjectResponse
        {
            Id = project.Id,
            Name = project.Name,
            Location = project.Location,
            Type = Enum.Parse<PropertyType>(project.Type),
            MinPrice = project.MinPrice,
            MaxPrice = project.MaxPrice,
            Status = Enum.Parse<ProjectStatus>(project.Status),
            Images = project.Images,
            Description = project.Description,
            Latitude = project.Latitude,
            Longitude = project.Longitude
        };
    }
}
