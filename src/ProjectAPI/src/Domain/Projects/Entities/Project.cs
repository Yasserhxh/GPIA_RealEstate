using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Domain.Projects.Entities
{
    /// <summary>
    /// Represents a real estate project.
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
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the project (e.g., residential, commercial).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the minimum price of the project.
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price of the project.
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the images associated with the project.
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

        /// <summary>
        /// Gets or sets the status of the project (e.g., ComingSoon, Available).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of assignments associated with the project.
        /// </summary>
        public ICollection<ProjectAssignment> Assignments { get; set; }

        /// <summary>
        /// Gets or sets the collection of appointments associated with the project.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; }

        /// <summary>
        /// Gets or sets the collection of units in the project.
        /// </summary>
        public ICollection<Unit> Units { get; set; } = new List<Unit>();

        /// <summary>
        /// Gets or sets the number of units available in the project.
        /// </summary>
        public int NumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the Min sellable surface area range of the project.
        /// </summary>
        public int MinSellableSurfaceRange { get; set; }
        /// <summary>
        /// Gets or sets the Max sellable surface area range of the project.
        /// </summary>
        public int MaxSellableSurfaceRange { get; set; }

    }
}
