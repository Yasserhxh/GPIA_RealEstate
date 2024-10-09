using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Domain.FeedBacks.Entities;

/// <summary>
/// Represents feedback given by a user, which can be on a project or the application.
/// </summary>
public class Feedback
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid? ProjectId { get; set; } // Nullable, indicating feedback can be on the application if null
    public int Rating { get; set; } // Rating from 1 to 5
    public string Comments { get; set; } // Feedback comments
    public List<string> Attachments { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public User User { get; set; } // This references the User who gave the feedback
    public Project FeedBack_Project { get; set; } 

}
