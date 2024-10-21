using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.UpdateProject
{
    /// <summary>
    /// Handler for the <see cref="UpdateProjectCommand"/>.
    /// </summary>
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ProjectResponse>
    {
        private readonly IProjectRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectHandler"/> class.
        /// </summary>
        /// <param name="repository">The project repository.</param>
        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the request to update a project.
        /// </summary>
        /// <param name="request">The request containing project update details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response containing the updated project details.</returns>
        public async Task<ProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
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

            return new ProjectResponse
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
                Longitude =project.Longitude
            };
        }
    }
}
