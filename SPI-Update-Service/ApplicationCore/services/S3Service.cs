using Amazon.S3;
using Amazon.S3.Model;
using domain.constants;
using SPI_Update_Service.Infrastructure.repositories;
using SPI_Update_Service.Proxy.interfaces;

namespace SPI_Update_Service.ApplicationCore.services
{
    public class S3Service : IS3Service
    {
        AmazonS3Client client;
        public S3Service(S3Repository repository) {
            client = repository.clientRepository();
        }
        public async Task<byte[]> getCertificate()
        {
            try
            {
                var request = new GetObjectRequest
                {
                    BucketName = Environment.GetEnvironmentVariable(ConstantsEnum.BUCKET_NAME.getValue()),
                    Key = Environment.GetEnvironmentVariable(ConstantsEnum.PATHS3.getValue())
                };

                using (var response = await client.GetObjectAsync(request))
                using (var memoryStream = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    return memoryStream.ToArray();
                }

            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"[ERROR] Error S3: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error general: {ex.Message}");
                throw;
            }

        }   
    }
}
