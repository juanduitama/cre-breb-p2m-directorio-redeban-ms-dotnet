using Microsoft.Extensions.Configuration;
using SPI_Update_Enterprise_Service.Domain.constants;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace SPI_Update_Enterprise_Service.Utils.util
{
    /// <summary>
    /// clase builderhttp
    /// </summary>
    public class BuilderHttpUtil
    {
        public HttpClient BuildClientWithClientCertificate(byte[] file)
        {
            try
            {
                Console.WriteLine("[INFO] Configurando HttpClient con certificado de cliente (.pfx)");

                var handler = new HttpClientHandler
                {
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
                };

                var clientCertificate = new X509Certificate2(file, Environment.GetEnvironmentVariable(ConstantsEnums.PSW_CERTIFICATE.getValue()));
                handler.ClientCertificates.Add(clientCertificate);

                return new HttpClient(handler);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error en la construcción del cliente {ex.Message}");
                throw new SerfiException(ResponseServiceEnums.SERVICE_HTTP_ERROR.getErrorCode(),
                                        ResponseServiceEnums.SERVICE_HTTP_ERROR.getMessage(),
                                        ResponseServiceEnums.SERVICE_HTTP_ERROR.getHttpCode());
            }
        }

        public void ClearHeaders(HttpClient _httpClient)
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }
    }
}