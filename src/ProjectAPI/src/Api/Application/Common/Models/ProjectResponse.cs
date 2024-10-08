
namespace ProjectAPI.Api.Application.Common.Models
{
    public enum PropertyType { Villa, Apartment, Commercial }
    public enum ProjectStatus { ComingSoon, UnderConstruction, Available, Sold }

    public class ProjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public PropertyType Type { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public ProjectStatus Status { get; set; }
        public string Images { get; set; } // JSON for image URLs
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
