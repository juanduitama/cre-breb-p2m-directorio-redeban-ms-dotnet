using Amazon;
using Amazon.S3;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Utils.util;

namespace SPI_Update_Enterprise_Service.Infrastructure.repositories
{
    public class S3Repository
    {
        public AmazonS3Client clientRepository()
        {
            var s3Config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };
            return new AmazonS3Client(s3Config);
        }
    }
}
