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
        public HttpClient BuildClientWithClientCertificate()
        {
            Console.WriteLine("[INFO] Configurando HttpClient con certificado de cliente (.pfx)");

            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
            };

            var clientCertificate = new X509Certificate2(Environment.GetEnvironmentVariable(ConstantsEnum.CERT_ROUTE.getValue()), Environment.GetEnvironmentVariable(ConstantsEnum.PSW_CERTIFICATE.getValue()));
            handler.ClientCertificates.Add(clientCertificate);

            return new HttpClient(handler);
        }
    }
}