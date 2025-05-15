using Amazon.DynamoDBv2.DataModel;
using domain.models.redeban;
using SPI_Update_Service.Domain.models.dynamo;
using SPI_Update_Service.Proxy.interfaces;

namespace SPI_Update_Service.ApplicationCore.services
{
    public class DynamoService : IDynamoService
    {
        public async Task delete(DynamoDBContext dynamoContext, KeyEntity keyEntity)
        {
            await dynamoContext.DeleteAsync(keyEntity);
        }

        public async Task<KeyEntity> load(DynamoDBContext dynamoContext, string id, string sk)
        {
            return await dynamoContext.LoadAsync <KeyEntity>(id, sk);
        }

        public async Task save(DynamoDBContext dynamoContext, KeyEntity keyEntity)
        {
            await dynamoContext.SaveAsync(keyEntity);
        }
    }
}
