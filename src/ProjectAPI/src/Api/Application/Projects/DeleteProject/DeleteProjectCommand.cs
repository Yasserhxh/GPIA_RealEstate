namespace ProjectAPI.Api.Application.Projects.DeleteProject;

/// <summary>
/// Command for deleting a project.
/// </summary>
public class DeleteProjectCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets the ID of the project to delete.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProjectCommand"/> class.
    /// </summary>
    /// <param name="id">The ID of the project to delete.</param>
    public DeleteProjectCommand(Guid id)
    {
        Id = id;
    }
}
