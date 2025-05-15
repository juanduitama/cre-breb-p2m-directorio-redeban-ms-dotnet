using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using domain.constants;

namespace SPI_Update_Service.infrastructure.repositories
{
    public class DynamoRepository
    {

        public async Task<DynamoDBContext> clientRepository(string region, string url)
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(region),
                    ServiceURL = url
                };


                AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);

                DynamoDBContext context = new DynamoDBContext(client);

                return context;
            }
            catch (Exception ex)
            {
                throw new SerfiException(ResponseServiceEnum.DYNAMO_CLIENT_ERROR.getErrorCode(), ResponseServiceEnum.DYNAMO_CLIENT_ERROR.getMessage(), ResponseServiceEnum.DYNAMO_CLIENT_ERROR.getHttpCode());
            }
        }
    }
}
