namespace ProjectAPI.Api.Application.Projects.CreateProject
{
    /// <summary>
    /// Represents the response for the creation of a project.
    /// </summary>
    public class CreateProjectResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created project.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the message indicating the status of the project creation.
        /// </summary>
        public string Message { get; set; }
    }
}