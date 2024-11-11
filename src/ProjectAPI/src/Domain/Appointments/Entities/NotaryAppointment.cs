namespace ProjectAPI.Domain.Appointments.Entities;

/// <summary>
/// Represents an appointment with a notary.
/// </summary>
public class NotaryAppointment
{
    public Guid Id { get; set; }
    public string UserId { get; set; } // The user making the appointment
    public Guid SaleId { get; set; } // The sale associated with this appointment
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } // e.g., Scheduled, Completed, Cancelled
}
