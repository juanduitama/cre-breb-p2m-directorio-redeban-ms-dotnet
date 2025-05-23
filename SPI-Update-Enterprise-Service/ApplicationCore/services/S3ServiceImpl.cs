using Amazon.S3.Model;
using Amazon.S3;
using SPI_Update_Enterprise_Service.ApplicationCore.interfaces;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Infrastructure.repositories;
using SPI_Update_Enterprise_Service.Utils.util;

namespace SPI_Update_Enterprise_Service.ApplicationCore.services
{
    public class S3ServiceImpl : IS3Service
    {
        AmazonS3Client client;
        public S3ServiceImpl(S3Repository repository)
        {
            client = repository.clientRepository();
        }
        public async Task<byte[]> getCertificate()
        {
            try
            {
                var request = new GetObjectRequest
                {
                    BucketName = Environment.GetEnvironmentVariable(ConstantsEnums.BUCKET_NAME.getValue()),
                    Key = Environment.GetEnvironmentVariable(ConstantsEnums.PATHS3.getValue())
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
                Console.WriteLine($"[ERROR] Error en S3 {ex.Message}");
                throw new SerfiException(ResponseServiceEnums.SERVICE_S3_ERROR.getErrorCode(),
                                        ResponseServiceEnums.SERVICE_S3_ERROR.getMessage(),
                                        ResponseServiceEnums.SERVICE_S3_ERROR.getHttpCode());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error general: {ex.Message}");
                throw new SerfiException(ResponseServiceEnums.SERVICE_INTERNAL_ERROR.getErrorCode(),
                                        ResponseServiceEnums.SERVICE_INTERNAL_ERROR.getMessage(),
                                        ResponseServiceEnums.SERVICE_INTERNAL_ERROR.getHttpCode());
            }

        }
    }
}
