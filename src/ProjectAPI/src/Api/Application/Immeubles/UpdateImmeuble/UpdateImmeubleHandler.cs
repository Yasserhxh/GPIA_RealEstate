using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Immeubles.Interfaces;

namespace ProjectAPI.Api.Application.Immeubles.UpdateImmeuble
{
    /// <summary>
    /// Handler for the <see cref="UpdateImmeubleCommand"/>.
    /// </summary>
    public class UpdateImmeubleHandler : IRequestHandler<UpdateImmeubleCommand, ImmeubleResponse>
    {
        private readonly IImmeubleRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateImmeubleHandler"/> class.
        /// </summary>
        /// <param name="repository">The project repository.</param>
        public UpdateImmeubleHandler(IImmeubleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the request to update a project.
        /// </summary>
        /// <param name="request">The request containing project update details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response containing the updated project details.</returns>
        public async Task<ImmeubleResponse> Handle(UpdateImmeubleCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIDAsync(request.Id) ?? throw new NotFoundException($"Project with ID {request.Id} not found.");
            project.Name = request.Name;
            project.Location = request.Location;
            project.Type = request.Type.ToString();
            project.MinPrice = request.MinPrice;
            project.MaxPrice = request.MaxPrice;
            project.Status = request.Status.ToString();
            project.Images = request.Images;
            project.Description = request.Description;
            project.Latitude = request.Latitude;
            project.Longitude = request.Longitude;
            project.MaxSellableSurfaceRange = request.MaxSellableSurfaceRange;
            project.MinSellableSurfaceRange = request.MinSellableSurfaceRange;

            _repository.Update(project);
            await _repository.SaveAsync();

            return new ImmeubleResponse
            {
                Id = project.Id,
                Name = project.Name,
                Location = project.Location,
                Type = request.Type,
                MinPrice = project.MinPrice,
                MaxPrice = project.MaxPrice,
                Status = request.Status,
                Images = project.Images,
                Description = project.Description,
                Latitude = project.Latitude,
                Longitude = project.Longitude
            };
        }
    }
}
