namespace ProjectAPI.Domain.Users.Entities;

/// <summary>
/// Represents a performance indicator for an agent.
/// </summary>
public class PerformanceIndicator
{
    public Guid Id { get; set; }
    public string AgentId { get; set; }
    public Agent Agent { get; set; }
    public int LeadsGenerated { get; set; } // Number of leads generated
    public int AppointmentsScheduled { get; set; } // Number of appointments scheduled
    public int SuccessfulSales { get; set; } // Number of sales completed
    public double ConversionRate { get; set; } // (SuccessfulSales / LeadsGenerated) * 100
    public DateTime RecordedAt { get; set; }
}