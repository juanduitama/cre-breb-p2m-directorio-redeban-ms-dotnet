using Amazon.DynamoDBv2.DataModel;
using domain.constants;

namespace SPI_Update_Service.Domain.models.dynamo
{

    [DynamoDBTable("nombreTabla")]
    public class KeyEntity
    {
        [DynamoDBHashKey]
        public string id { get; set; }

        [DynamoDBRangeKey]
        public string sk { get; set; }

        [DynamoDBProperty]
        public string status { get; set; }
    }
}
