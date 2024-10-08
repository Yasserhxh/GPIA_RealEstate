using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Projects.GetAllProjects
{
    /// <summary>
    /// Query for getting all projects.
    /// </summary>
    public class GetAllProjectsQuery : IRequest<PaginatedResponse<ProjectResponse>>
    {
        /// <summary>
        /// The name of the project to filter by.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The location of the project to filter by.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// The type of the project to filter by.
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// The minimum price of the project to filter by.
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// The maximum price of the project to filter by.
        /// </summary>
        public decimal? MaxPrice { get; set; }

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
