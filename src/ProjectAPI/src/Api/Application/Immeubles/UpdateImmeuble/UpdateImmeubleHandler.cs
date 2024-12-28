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
            var immeuble = await _repository.GetByIDAsync(request.Id) ?? throw new NotFoundException($"Immeuble with ID {request.Id} not found.");

            // Dictionary to manage field updates dynamically
            var updateActions = new Dictionary<Func<bool>, Action>
            {
                { () => !string.IsNullOrWhiteSpace(request.Name), () => immeuble.Name = request.Name },
                { () => !string.IsNullOrWhiteSpace(request.Location), () => immeuble.Location = request.Location },
                { () => !string.IsNullOrWhiteSpace(request.Type), () => immeuble.Type = request.Type },
                { () => request.MinPrice > 0, () => immeuble.MinPrice = request.MinPrice },
                { () => request.MaxPrice > 0, () => immeuble.MaxPrice = request.MaxPrice },
                { () => request.Status.HasValue, () => immeuble.Status = request.Status!.Value.ToString() }, // Enum update
                { () => request.Images != null && request.Images.Any(), () => immeuble.Images = request.Images },
                { () => !string.IsNullOrWhiteSpace(request.Description), () => immeuble.Description = request.Description },
                { () => request.Latitude != 0, () => immeuble.Latitude = request.Latitude },
                { () => request.Longitude != 0, () => immeuble.Longitude = request.Longitude },
                { () => request.MaxSellableSurfaceRange > 0, () => immeuble.MaxSellableSurfaceRange = request.MaxSellableSurfaceRange },
                { () => request.MinSellableSurfaceRange > 0, () => immeuble.MinSellableSurfaceRange = request.MinSellableSurfaceRange }
            };

            // Apply updates only if conditions are met
            foreach (var updateAction in updateActions)
            {
                if (updateAction.Key.Invoke())
                {
                    updateAction.Value.Invoke();
                }
            }

            _repository.Update(immeuble);
            await _repository.SaveAsync();

            return new ImmeubleResponse
            {
                Id = immeuble.Id,
                Name = immeuble.Name,
                Location = immeuble.Location,
                Type = immeuble.Type,
                MinPrice = immeuble.MinPrice,
                MaxPrice = immeuble.MaxPrice,
                Status = Enum.Parse<ProjectStatus>(immeuble.Status),
                Images = immeuble.Images,
                Description = immeuble.Description,
                Latitude = immeuble.Latitude,
                Longitude = immeuble.Longitude
            };
        }
    }
}
