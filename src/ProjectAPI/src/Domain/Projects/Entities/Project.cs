using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Domain.Projects.Entities
{
    /// <summary>
    /// Represents a real estate project, including details such as its name, location, type, pricing, associated units, and status.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the unique identifier of the project.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the project.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the project (e.g., F1, F2, F3,...).
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// Gets or sets the type of the project (e.g., Commercial, Villa, Appartement,...).
        /// </summary>
        public string? ResidencyType { get; set; }

        /// <summary>
        /// Gets or sets the minimum price of properties in the project.
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price of properties in the project.
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the image URLs associated with the project.
        /// </summary>
        public string? Images { get; set; }

        /// <summary>
        /// Gets or sets the 3D module link for the project visualization.
        /// </summary>
        public string? Module3DLink { get; set; }

        /// <summary>
        /// Gets or sets the description of the project.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the project's location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the project's location.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the status of the project (e.g., ComingSoon, Available).
        /// </summary>
        public string Status { get; set; }
        public string? AgentId { get; set; }

        /// <summary>
        /// Gets or sets the collection of assignments associated with the project, representing agents and their responsibilities.
        /// </summary>
        public ICollection<ProjectAssignment> Assignments { get; set; }
        public Agent Agent { get; set; }

        /// <summary>
        /// Gets or sets the collection of appointments associated with the project, representing user interactions.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; }

        /// <summary>
        /// Gets or sets the collection of units available in the project.
        /// </summary>
        public ICollection<Unit> Units { get; set; } = new List<Unit>();

        /// <summary>
        /// Gets or sets the total number of units available in the project.
        /// </summary>
        public int NumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the total number of units sold in the project.
        /// </summary>
        public int NumberOfSoldUnites { get; set; }

        /// <summary>
        /// Gets or sets the total number of units still available in the project.
        /// </summary>
        public int NumberOfAvailableUnites { get; set; }

        /// <summary>
        /// Gets or sets the percentage of units sold in the project.
        /// </summary>
        public int SellsPercentage { get; set; }

        /// <summary>
        /// Gets or sets the minimum sellable surface area in square meters for the project.
        /// </summary>
        public int MinSellableSurfaceRange { get; set; }

        /// <summary>
        /// Gets or sets the maximum sellable surface area in square meters for the project.
        /// </summary>
        public int MaxSellableSurfaceRange { get; set; }
    }
}
