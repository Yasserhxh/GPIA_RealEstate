using Als.Foundation.Data.Abstractions.BlobStorage;

namespace ProjectAPI.Domain.Common.Interfaces;
public interface IBlobStorageService : IBaseBlobStorage
{
    Task<bool> DeleteBlobAsync(string fileName, CancellationToken cancellationToken);
}
