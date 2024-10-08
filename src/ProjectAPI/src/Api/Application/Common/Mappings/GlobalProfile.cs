using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Projects.Entities;
namespace ProjectAPI.Api.Application.Common.Mappings
{
    /// <summary>
    /// Represents a global profile used for configuring type adapters.
    /// </summary>
    public class GlobalProfile : IRegister
    {
        /// <summary>
        /// Registers type adapters for mapping between types.
        /// </summary>
        /// <param name="config">The type adapter configuration.</param>
        public void Register(TypeAdapterConfig config)
        {
         
            //.Map(dest => dest.UserAssignment, src => src.GetUserAssignmentEntity());

            // Mapping configuration for Project to ProjectResponse
            config.NewConfig<Project, ProjectResponse>();
        }
    }
}