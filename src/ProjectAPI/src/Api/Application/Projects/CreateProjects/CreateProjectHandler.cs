using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.CreateProjects;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        // Create a new Project entity
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Location = request.Location,
            Address = request.Address,
            Description = request.Description,
            Module3DLink = request.Module3DLink,
            Images = request.Images
        };

        // Save to the repository
        await _projectRepository.InsertAsync(project);
        await _projectRepository.SaveAsync();
        // Map to response
        return new CreateProjectResponse
        {
            Id = project.Id,
            Message = "Project created successfuly"
        };
    }
}