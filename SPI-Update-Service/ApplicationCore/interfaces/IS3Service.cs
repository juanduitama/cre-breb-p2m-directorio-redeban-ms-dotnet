using Amazon.DynamoDBv2.DataModel;
using Amazon.S3;
using domain.models.oAuth;
using SPI_Update_Service.Domain.models.dynamo;

namespace SPI_Update_Service.Proxy.interfaces
{
    public interface IS3Service
    {
        Task<byte[]> getCertificate();
    }
}
