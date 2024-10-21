namespace ProjectAPI.Api.Application.Projects.CreateProject;

/// <summary>
/// Command to create a new project.
/// </summary>
public class CreateProjectCommand : IRequest<Guid>
{
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
    /// Gets or sets the number of units in the project.
    /// </summary>
    public int NumberOfUnits { get; set; }

    /// <summary>
    /// Gets or sets the minimum sellable surface area range of the project.
    /// </summary>
    public int MinSellableSurfaceRange { get; set; }

    /// <summary>
    /// Gets or sets the maximum sellable surface area range of the project.
    /// </summary>
    public int MaxSellableSurfaceRange { get; set; }
}