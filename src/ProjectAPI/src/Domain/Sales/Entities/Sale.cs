namespace ProjectAPI.Domain.Sales.Entities;
/// <summary>
/// Represents a sale made by an agent to a user.
/// </summary>
public class Sale
{
    public Guid Id { get; set; }
    public string BuyerId { get; set; }  // User ID of the buyer
    public Guid UnitId { get; set; }     // Unit being sold
    public DateTime SaleDate { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsUnderConstruction { get; set; } // To indicate if the unit is still under construction
    public ICollection<PaymentTracking> Payments { get; set; } = new List<PaymentTracking>();
    public ICollection<PropertyDelivery> PropertyDeliveries { get; set; } = new List<PropertyDelivery>();

}
