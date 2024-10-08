namespace ProjectAPI.Api.Application.Common.Models;
public enum AppointmentStatus { Confirmed, Cancelled, Completed }
public class AppointmentResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Notes { get; set; }
}
