using Amazon;
using Amazon.S3;
using domain.constants;

namespace SPI_Update_Service.Infrastructure.repositories
{
    public class S3Repository
    {
        public AmazonS3Client clientRepository() {

            try
            {
                Console.WriteLine("Inicia client repository en s3. ");
                var s3Config = new AmazonS3Config
                {
                    RegionEndpoint = RegionEndpoint.USEast1
                };
                Console.WriteLine("Finaliza client repository en s3. ");
                return new AmazonS3Client(s3Config);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al configurar el cliente en s3: " + ex.Message);
                throw new SerfiException(ResponseServiceEnum.ERROR_S3.getErrorCode(), ResponseServiceEnum.ERROR_S3.getMessage(), ResponseServiceEnum.ERROR_S3.getHttpCode());
            }
        }
    }
}
