using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Projects.Interfaces;

namespace ProjectAPI.Api.Application.Projects.LikedProjects.AddLikedProject;

public class AddLikedProjectHandler : IRequestHandler<AddLikedProjectCommand, LikedProjectResponse>
{
    private readonly ILikedProjectRepository _repository;

    public AddLikedProjectHandler(ILikedProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<LikedProjectResponse> Handle(AddLikedProjectCommand request, CancellationToken cancellationToken)
    {
        var likedProject = new LikedProject
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            ProjectId = request.ProjectId,
            LikedAt = DateTime.UtcNow
        };

        await _repository.InsertAsync(likedProject);
        await _repository.SaveAsync();

        return new LikedProjectResponse
        {
            Id = likedProject.Id,
            UserId = likedProject.UserId,
            ProjectId = likedProject.ProjectId,
            LikedAt = likedProject.LikedAt
        };
    }
}
