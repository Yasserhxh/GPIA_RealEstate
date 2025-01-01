using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Immeubles.Entities;

namespace ProjectAPI.Domain.Projects.Entities;

/// <summary>
/// Represents a real estate project containing multiple Immeubles.
/// </summary>
public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string Module3DLink { get; set; }
    public List<string> Images { get; set; } = new List<string>();

    // Navigation property
    public ICollection<Immeuble> Immeubles { get; set; } = new List<Immeuble>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
