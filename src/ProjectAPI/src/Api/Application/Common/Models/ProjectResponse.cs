namespace ProjectAPI.Api.Application.Common.Models;

public class ProjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public bool IsLiked { get; set; } // New attribute

}
