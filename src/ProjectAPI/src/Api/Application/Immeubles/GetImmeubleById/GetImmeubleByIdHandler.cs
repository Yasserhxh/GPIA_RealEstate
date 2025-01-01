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
        var immeubles = await _repository.Find(p=>p.Id==request.Id, includes:p=>p.PlanInterieurs);
        var immeuble = immeubles.FirstOrDefault();
        if (immeuble == null)
        {
            throw new NotFoundException($"Project with ID {request.Id} not found.");
        }

        return new ImmeubleResponse
        {
            Id = immeuble.Id,
            ProjectId = immeuble.ProjectId,
            Name = immeuble.Name,
            Location = immeuble.Location,
            Type = immeuble.Type,
            MinPrice = immeuble.MinPrice,
            MaxPrice = immeuble.MaxPrice,
            Status = Enum.Parse<ProjectStatus>(immeuble.Status),
            Images = [.. immeuble.Images.Split(',')],
            Description = immeuble.Description,
            Latitude = immeuble.Latitude,
            Longitude = immeuble.Longitude,
            NumberOfUnits = immeuble.NumberOfUnits,
            MaxSellableSurfaceRange = immeuble.MaxSellableSurfaceRange,
            MinSellableSurfaceRange = immeuble.MinSellableSurfaceRange,
            Module3DLink = immeuble.Module3DLink,
            NumberOfAvailableUnites = immeuble.NumberOfUnits,
            NumberOfSoldUnites = immeuble.NumberOfSoldUnites,
            SellsPercentage = immeuble.SellsPercentage,
            PlanInerieurs = immeuble.PlanInterieurs.Select(pi => new PlanInerieurResponse
            {
                Id = pi.Id,
                ImmeubleId = pi.ImmeubleId,
                PhotoLinks = pi.PhotoLinks
            }).ToList()
        };
    }
}
