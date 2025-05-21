using Amazon;
using Amazon.S3;

namespace SPI_Update_Service.Infrastructure.repositories
{
    public class S3Repository
    {
        public AmazonS3Client clientRepository() {

            var s3Config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };
            return new AmazonS3Client(s3Config);
        }
    }
}
