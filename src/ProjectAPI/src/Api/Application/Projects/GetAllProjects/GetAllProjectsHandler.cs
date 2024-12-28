using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Interfaces;
using ProjectAPI.Infrastructure.Migrations;

namespace ProjectAPI.Api.Application.Projects.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, PaginatedResponse<ProjectResponse>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly ILikedProjectRepository _likedProjectRepository;

    public GetAllProjectsHandler(IProjectRepository projectRepository, ILikedProjectRepository likedProjectRepository)
    {
        _projectRepository = projectRepository;
        _likedProjectRepository = likedProjectRepository;
    }

    public async Task<PaginatedResponse<ProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        // Get all liked project IDs for the current user
       /* var likedProjects = await _likedProjectRepository
            .Find(lp => lp.UserId == request.UserId);*/

        //var likedProjectIds = likedProjects.Select(lp => lp.ProjectId);

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
                Images = project.Images,
                //IsLiked = likedProjectIds.Contains(project.Id)

             }).ToList();
        return new PaginatedResponse<ProjectResponse>(paginatedData, request.PageNumber, request.PageSize, totalItems);

    }
}