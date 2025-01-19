using ProjectAPI.Domain.Immeubles.Entities;

namespace ProjectAPI.Domain.Reservations.Entities
{
    /// <summary>
    /// Represents a reservation for a property/unit.
    /// </summary>
    public class Reservation
    {
        public Guid Id { get; set; }

        // Buyer Information
        public string? BuyerId { get; set; } // If the buyer is a registered user
        public string? Name { get; set; } // For unregistered buyer
        public string? LastName { get; set; }
        public string? CIN { get; set; } // National ID for Morocco
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // Reservation Details
        public Guid UnitId { get; set; }
        public string? UnitDetails { get; set; } // JSON or formatted string with unit info
        public string? AgentId { get; set; } // The agent who made the reservation
        public decimal TotalPropertyPrice { get; set; } // Total price of the property
        public decimal ReservationAmount { get; set; } // Amount paid during reservation
        public DateTime ReservationDate { get; set; }
        public bool IsUnderConstruction { get; set; } // Whether the property is under construction

        // Navigation properties
        public Unit Unit { get; set; }
    }
}
