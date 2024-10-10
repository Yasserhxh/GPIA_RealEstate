namespace ProjectAPI.Api.Application.Common.Models
{
    /// <summary>
    /// Enumeration for the type of property.
    /// </summary>
    public enum PropertyType { Villa, Apartment, Commercial }

    /// <summary>
    /// Enumeration for the status of a project.
    /// </summary>
    public enum ProjectStatus { ComingSoon, UnderConstruction, Available, Sold }

    /// <summary>
    /// Represents the response model for project details.
    /// </summary>
    public class ProjectResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the project.
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
        /// Gets or sets the type of property (e.g., Villa, Apartment, Commercial).
        /// </summary>
        public PropertyType Type { get; set; }

        /// <summary>
        /// Gets or sets the minimum price for properties in the project.
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price for properties in the project.
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the current status of the project.
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the image URLs for the project, represented as JSON.
        /// </summary>
        public string Images { get; set; } // JSON for image URLs

        /// <summary>
        /// Gets or sets the description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the project's location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the project's location.
        /// </summary>
        public double Longitude { get; set; }
    }
}