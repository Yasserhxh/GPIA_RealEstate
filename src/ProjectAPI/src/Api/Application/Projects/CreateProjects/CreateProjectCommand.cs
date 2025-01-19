﻿namespace ProjectAPI.Api.Application.Projects.CreateProjects;

public class CreateProjectCommand : IRequest<CreateProjectResponse>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set; }
    public string? Module3DLink { get; set; }
    public List<string> Images { get; set; } = new List<string>();
}