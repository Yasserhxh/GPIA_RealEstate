using ProjectAPI.Domain.Immeubles.Interfaces;
using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Projects.Interfaces;
using ProjectAPI.Domain.Users.Entities;
using ProjectAPI.Domain.Users.Interfaces;

namespace ProjectAPI.Api.Application.Projects.LikedProjects.AddLikedProject
{
    public class AddLikedProjectHandler : IRequestHandler<AddLikedProjectCommand, LikedProjectResponse>
    {
        private readonly ILikedProjectRepository _repository;
        private readonly IImmeubleRepository _immeubleRepository;
        private readonly IPerformanceIndicatorRepository _performanceIndicatorRepository;
        private readonly ILeadRepository _leadRepository;

        public AddLikedProjectHandler(
            ILikedProjectRepository repository,
            IImmeubleRepository immeubleRepository,
            IPerformanceIndicatorRepository performanceIndicatorRepository,
            ILeadRepository leadRepository)
        {
            _repository = repository;
            _immeubleRepository = immeubleRepository;
            _performanceIndicatorRepository = performanceIndicatorRepository;
            _leadRepository = leadRepository;
        }

        public async Task<LikedProjectResponse> Handle(AddLikedProjectCommand request, CancellationToken cancellationToken)
        {
            // Add liked project
            var likedProject = new LikedProject
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                LikedAt = DateTime.UtcNow
            };

            await _repository.InsertAsync(likedProject);

            // Generate leads
            var immeubles = await _immeubleRepository.Find(i => i.ProjectId == request.ProjectId);

            foreach (var immeuble in immeubles)
            {
                var lead = new Lead
                {
                    Id = Guid.NewGuid(),
                    ProjectId = request.ProjectId,
                    UserId = request.UserId,
                    AgentId = immeuble.AgentId,
                    CreatedAt = DateTime.UtcNow
                };

                await _leadRepository.InsertAsync(lead);

                // Update performance indicators for the agent
                var performanceIndicator = await _performanceIndicatorRepository.Find(i=>i.AgentId == immeuble.AgentId);
                if (performanceIndicator != null && performanceIndicator.Any())
                {
                    performanceIndicator.FirstOrDefault()!.IncrementLeadsGenerated();
                    _performanceIndicatorRepository.Update(performanceIndicator.FirstOrDefault()!);
                }
            }

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
}
