using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Immeubles.Interfaces;

namespace ProjectAPI.Api.Application.Immeubles.GetImmeubleById;

/// <summary>
/// Handler for the <see cref="GetImmeubleByIdQuery"/>.
/// </summary>
public class GetImmeubleByIdHandler : IRequestHandler<GetImmeubleByIdQuery, ImmeubleResponse>
{
    private readonly IImmeubleRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetImmeubleByIdHandler"/> class.
    /// </summary>
    /// <param name="repository">The project repository.</param>
    public GetImmeubleByIdHandler(IImmeubleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the request to get a project by its ID.
    /// </summary>
    /// <param name="request">The request containing the project ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response containing the project details.</returns>
    public async Task<ImmeubleResponse> Handle(GetImmeubleByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIDAsync(request.Id);

        if (project == null)
        {
            throw new NotFoundException($"Project with ID {request.Id} not found.");
        }

        return new ImmeubleResponse
        {
            Id = project.Id,
            Name = project.Name,
            Location = project.Location,
            Type = project.Type,
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
