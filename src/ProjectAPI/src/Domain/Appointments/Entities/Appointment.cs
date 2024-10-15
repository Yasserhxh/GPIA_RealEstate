using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Domain.Appointments.Entities;

/// <summary>
/// Represents an appointment related to a project, including details such as project, agent, and guest or authenticated user information.
/// This class contains information like appointment date, related project, assigned agent, guest or user details, and the status of the appointment.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Gets or sets the unique identifier for the appointment.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the related project.
    /// </summary>
    public Guid ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the agent managing the appointment.
    /// </summary>
    public string AgentId { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the appointment.
    /// </summary>
    public DateTime AppointmentDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with the appointment.
    /// If the user is not authenticated, this field will be null.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the overall status of the appointment.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the name of the guest if the user is not authenticated.
    /// </summary>
    public string Name { get; set; } // Guest Name if not authenticated

    /// <summary>
    /// Gets or sets the last name of the guest if the user is not authenticated.
    /// </summary>
    public string LastName { get; set; } // Guest Last Name if not authenticated

    /// <summary>
    /// Gets or sets the email of the guest if the user is not authenticated.
    /// </summary>
    public string Email { get; set; } // Guest email if not authenticated

    /// <summary>
    /// Gets or sets the phone number of the guest if the user is not authenticated.
    /// </summary>
    public string PhoneNumber { get; set; } // Guest phone if not authenticated

    /// <summary>
    /// Gets or sets the project associated with the appointment.
    /// </summary>
    public Project Project { get; set; }

    /// <summary>
    /// Gets or sets the agent associated with the appointment.
    /// </summary>
    public Agent Agent { get; set; }

    /// <summary>
    /// Gets or sets the collection of reviews for the appointment.
    /// </summary>
    public ICollection<AppointmentReview> Reviews { get; set; }
}