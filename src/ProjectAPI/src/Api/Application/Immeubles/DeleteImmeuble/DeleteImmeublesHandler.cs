using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Domain.Immeubles.Interfaces;

namespace ProjectAPI.Api.Application.Immeubles.DeleteImmeuble;

/// <summary>
/// Handler for the <see cref="DeleteImmeublesCommand"/>.
/// </summary>
public class DeleteImmeublesHandler : IRequestHandler<DeleteImmeublesCommand, Unit>
{
    private readonly IImmeubleRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteImmeublesHandler"/> class.
    /// </summary>
    /// <param name="repository">The project repository.</param>
    public DeleteImmeublesHandler(IImmeubleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the request to delete a project.
    /// </summary>
    /// <param name="request">The request containing the project ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A unit result indicating the completion of the request.</returns>
    public async Task<Unit> Handle(DeleteImmeublesCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIDAsync(request.Id) ?? throw new NotFoundException($"Project with ID {request.Id} not found.");
        await _repository.DeleteAsync(project);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}
