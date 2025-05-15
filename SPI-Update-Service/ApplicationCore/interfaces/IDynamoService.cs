using Amazon.DynamoDBv2.DataModel;
using domain.models.oAuth;
using SPI_Update_Service.Domain.models.dynamo;

namespace SPI_Update_Service.Proxy.interfaces
{
    public interface IDynamoService
    {
        Task <KeyEntity>load(DynamoDBContext dynamoContext, string id, string sk);
        Task save(DynamoDBContext dynamoContext, KeyEntity keyEntity);

        Task delete(DynamoDBContext dynamoContext, KeyEntity keyEntity);
    }
}
