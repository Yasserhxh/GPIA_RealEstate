using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, PaginatedResponse<ProjectResponse>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<PaginatedResponse<ProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.Find(
          p => (string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name)) &&
               (string.IsNullOrEmpty(request.Location) || p.Location.Contains(request.Location)) &&
               (string.IsNullOrEmpty(request.Address) || p.Location.Contains(request.Address)),
          null
      );
        var totalItems = projects.Count();

        var paginatedData = projects
             .Skip((request.PageNumber - 1) * request.PageSize)
             .Take(request.PageSize).Select(project => new ProjectResponse
             {
                Id = project.Id,
                Name = project.Name,
                Location = project.Location,
                Address = project.Address,
                Images = project.Images
             }).ToList();
        return new PaginatedResponse<ProjectResponse>(paginatedData, request.PageNumber, request.PageSize, totalItems);

    }
}