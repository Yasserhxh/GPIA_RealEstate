using ProjectAPI.Api.Application.Common.BlobOperations.DeleteFromBlob;
using ProjectAPI.Api.Application.Common.BlobOperations.UpdateBlob;
using ProjectAPI.Api.Application.Common.BlobOperations.UploadToblob;
namespace ProjectAPI.Api.Controllers;

/// <summary>
/// Controller for file upload operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance.</param>
    public FileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Uploads a list of files to blob storage.
    /// </summary>
    /// <param name="files">The list of files to upload.</param>
    /// <returns>Returns the list of file links.</returns>
    [HttpPost("upload")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFiles(UploadFilesCommand command)
    {
        if (command.Files == null || command.Files.Count == 0)
        {
            return BadRequest("No files uploaded.");
        }

        var response = await _mediator.Send(command);
        return Ok(response);
    }
    /// <summary>
    /// Deletes a file from blob storage.
    /// </summary>
    /// <param name="fileName">The name of the file to delete.</param>
    /// <returns>Returns a success or failure message.</returns>
    [HttpDelete("delete/{fileName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteFile(string fileName)
    {
        var command = new DeleteFileCommand { FileName = fileName };
        var response = await _mediator.Send(command);
        return response.IsSuccess ? Ok(response.Message) : BadRequest(response.Message);
    }

    /// <summary>
    /// Updates a file in blob storage.
    /// </summary>
    /// <param name="fileName">The name of the file to update.</param>
    /// <param name="file">The new file to upload.</param>
    /// <returns>Returns the new file link.</returns>
    [HttpPut("update/{fileName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateFile(UpdateFileCommand command)
    {
        if (command.File == null || command.File.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var response = await _mediator.Send(command);
        return response.IsSuccess ? Ok(response.FileLink) : BadRequest(response.Message);
    }
}
