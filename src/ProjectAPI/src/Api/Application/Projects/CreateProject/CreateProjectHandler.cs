using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.CreateProject
{
    /// <summary>
    /// Handler for creating a new project.
    /// </summary>
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProjectHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository to handle project data operations.</param>
        public CreateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the creation of a new project.
        /// </summary>
        /// <param name="request">The command containing project details.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>The unique identifier of the created project.</returns>
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Location = request.Location,
                Type = request.Type,
                Images = request.Images,
                MinPrice = request.MinPrice,
                MaxPrice = request.MaxPrice,
                Description = request.Description,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                Status = "ComingSoon"
            };

            await _repository.InsertAsync(project);
            await _repository.SaveAsync();
            return project.Id;
        }
    }
}