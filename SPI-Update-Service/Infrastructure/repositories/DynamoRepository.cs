using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SPI_Update_Service.infrastructure.repositories
{
    public class DynamoRepository
    {

        public async Task<DynamoDBContext> clientRepository(string region, string url)
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
    }
}
