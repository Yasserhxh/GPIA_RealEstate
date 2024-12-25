using ProjectAPI.Domain.Sales.Entities;

namespace ProjectAPI.Domain.Immeubles.Entities;

/// <summary>
/// Represents a specific unit within a project.
/// </summary>
public class Unit
{
    /// <summary>
    /// Gets or sets the unique identifier for the unit.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the floor or level of the unit.
    /// </summary>
    public string Floor { get; set; } // e.g., "RDC", "1er", "2eme"

    /// <summary>
    /// Gets or sets the unit number.
    /// </summary>
    public string UnitNumber { get; set; } // e.g., "1-0-1"

    /// <summary>
    /// Gets or sets the number of bedrooms in the unit.
    /// </summary>
    public int? NumberOfBedrooms { get; set; }

    /// <summary>
    /// Gets or sets the number of bathrooms in the unit.
    /// </summary>
    public int? NumberOfBathrooms { get; set; }

    /// <summary>
    /// Gets or sets the surface area of the apartment.
    /// </summary>
    public double? ApartmentSurface { get; set; } // e.g., "72m2"

    /// <summary>
    /// Gets or sets the balcony surface area.
    /// </summary>
    public double? BalconySurface { get; set; } // e.g., "10m2"

    /// <summary>
    /// Gets or sets the terrace surface area.
    /// </summary>
    public double? TerraceSurface { get; set; } // e.g., "32m2"

    /// <summary>
    /// Gets or sets the garden surface area.
    /// </summary>
    public double? GardenSurface { get; set; } // e.g., "19m2"

    /// <summary>
    /// Gets or sets the view from the unit.
    /// </summary>
    public string View { get; set; } // e.g., "Jardin Piscine", "Traversant Jardin/Place Publique"

    /// <summary>
    /// Gets or sets the orientation of the unit.
    /// </summary>
    public string Orientation { get; set; } // e.g., "Ouest", "Ouest & Est"

    /// <summary>
    /// Gets or sets the total surface area of the unit (including balconies, terraces, etc.).
    /// </summary>
    public double? TotalSurface { get; set; }

    /// <summary>
    /// Gets or sets the saleable value of the unit using the first formula (50% balcony, 50% terrace, 30% garden).
    /// </summary>
    public double? SaleableValue { get; set; }

    /// <summary>
    /// Gets or sets the saleable value of the unit using the second formula (100% balcony, 50% terrace, 30% garden).
    /// </summary>
    public double? SaleableValue1 { get; set; }

    /// <summary>
    /// Gets or sets the price calculated using SaleableValue.
    /// </summary>
    public decimal? PriceSaleableValue { get; set; }

    /// <summary>
    /// Gets or sets the price calculated using SaleableValue1.
    /// </summary>
    public decimal? PriceSaleableValue1 { get; set; }

    /// <summary>
    /// Gets or sets the price as of the latest date (e.g., 06/11).
    /// </summary>
    public decimal? LatestPrice { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the related project.
    /// </summary>
    public Guid ProjectId { get; set; }

    /// <summary>
    /// Navigation property to the related project.
    /// </summary>
    public Immeuble Immeuble { get; set; }

    /// <summary>
    /// Navigation property for related property deliveries.
    /// </summary>
    public ICollection<PropertyDelivery> PropertyDeliveries { get; set; } = new List<PropertyDelivery>();
}
