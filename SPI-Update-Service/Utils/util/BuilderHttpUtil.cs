using Amazon.S3;
using domain.constants;
using Microsoft.Extensions.Configuration;
using SPI_Update_Service.ApplicationCore.services;
using SPI_Update_Service.Proxy.interfaces;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace SPI_Update_Service.Utils.util
{
    /// <summary>
    /// clase builderhttp
    /// </summary>
    public class BuilderHttpUtil
    {
        public BuilderHttpUtil()
        {
        }
        public HttpClient BuildClientWithClientCertificate(byte[] file)
        {
            try
            {
                Console.WriteLine("[INFO] Configurando HttpClient con certificado de cliente (.pfx)");
                string psw = Environment.GetEnvironmentVariable(ConstantsEnum.PASSWORD_CERTIFICATE.getValue());

                Console.WriteLine("psw: " + psw);

                var handler = new HttpClientHandler
                {
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
                };

                var clientCertificate = new X509Certificate2(file, psw);
                handler.ClientCertificates.Add(clientCertificate);

                return new HttpClient(handler);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consumir el certificado: " +  ex.Message);
                throw new SerfiException(ResponseServiceEnum.ERROR_CERTIFICATE.getErrorCode(), ResponseServiceEnum.ERROR_CERTIFICATE.getMessage(), ResponseServiceEnum.ERROR_CERTIFICATE.getHttpCode());
            }
        }
    }
}