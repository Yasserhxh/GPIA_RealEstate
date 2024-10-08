using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Projects.UpdateProject
{
    /// <summary>
    /// Command for updating a project.
    /// </summary>
    public class UpdateProjectCommand : IRequest<ProjectResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the project to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the project.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        public PropertyType Type { get; set; }

        /// <summary>
        /// Gets or sets the minimum price of the project.
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price of the project.
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the status of the project.
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the images of the project.
        /// </summary>
        public string Images { get; set; }

        /// <summary>
        /// Gets or sets the description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the project location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the project location.
        /// </summary>
        public double Longitude { get; set; }
    }

}
