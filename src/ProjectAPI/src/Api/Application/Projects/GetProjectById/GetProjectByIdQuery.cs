using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Projects.GetProjectById
{
    /// <summary>
    /// Query for getting a project by its ID.
    /// </summary>
    public class GetProjectByIdQuery : IRequest<ProjectResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the project.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProjectByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The ID of the project to retrieve.</param>
        public GetProjectByIdQuery(Guid id)
        {
            Id = id;
        }
    }

}
