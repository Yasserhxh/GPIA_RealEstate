namespace ProjectAPI.Domain.Reservation.Entities;

/// <summary>
/// Represents a reservation made by a user before purchasing a property.
/// </summary>
public class Reservation
{
    public Guid Id { get; set; }
    public string UserId { get; set; }  // The user who made the reservation
    public Guid UnitId { get; set; }    // The unit that is reserved
    public DateTime ReservationDate { get; set; }
    public string Status { get; set; }  // e.g., Pending, Approved, Cancelled
}