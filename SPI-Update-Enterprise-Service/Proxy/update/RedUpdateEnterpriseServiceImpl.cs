using SPI_Cancellation_Service.Domain.models.oAuth;
using SPI_Cancellation_Service.Proxy.interfaces;
using SPI_Update_Enterprise_Service.ApplicationCore.interfaces;
using SPI_Update_Enterprise_Service.Domain.constants;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using SPI_Update_Enterprise_Service.Domain.models.redeban;
using SPI_Update_Enterprise_Service.Domain.models.redeban.response;
using SPI_Update_Enterprise_Service.Proxy.interfaces;
using SPI_Update_Enterprise_Service.Utils.mapper;
using SPI_Update_Enterprise_Service.Utils.util;

namespace SPI_Update_Enterprise_Service.Proxy.update
{
    public class RedUpdateEnterpriseServiceImpl : IRedUpdateEnterpriseService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private readonly BuilderHttpUtil _BuilderHttpUtil;

        /// <summary>
        /// 
        /// </summary>
        private readonly RedRqMapper _redRqMapper;

        /// <summary>
        /// 
        /// </summary>
        private readonly IOAuthService _oauthService;

        public RedUpdateEnterpriseServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _redRqMapper = new RedRqMapper();
            _oauthService = new OAuthService();
        }
        public async Task<MsgInformationResponse> UpdateEnterpriseAsync(string url, HeadersRq headers, UpdateRqRed updateRqRed, IS3Service s3Service)
        {
            try
            {
                _httpClient = _BuilderHttpUtil.BuildClientWithClientCertificate(await s3Service.getCertificate());
                MsgInformationResponse responseRedeban = new MsgInformationResponse();

                Console.WriteLine($"[INFO] Iniciando solicitud PUT Cancelacion a: {url}");

                _BuilderHttpUtil.ClearHeaders(_httpClient);

                RsOAuth responseOauth = await _oauthService.getToken(Environment.GetEnvironmentVariable(ConstantsEnums.BASE_URI_OAUTH.getValue()), _httpClient);
                //RsOAuth responseOauth = await _oauthService.getToken(ConstantsEnums.BASE_URI_OAUTH.getValue(), _httpClient);

                Console.WriteLine("Token obtenido Oauth: " + responseOauth.accessToken);

                _BuilderHttpUtil.ClearHeaders(_httpClient);

                //Agregar cabeceras HTTP necesarias
                _redRqMapper.AddDeleteHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = UtilCommons.Object2String(updateRqRed);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnums.APPLICATION_JSON.getValue());

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PUT...");
                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[WARN] Respuesta de error: {responseContent}");

                responseRedeban = UtilCommons.String2Object<MsgInformationResponse>(responseContent);

                Console.WriteLine($"[RES] Respuesta: {responseContent}");

                return responseRedeban;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[ERROR] Error de solicitud HTTP: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"[ERROR] Inner Exception: {ex.InnerException.Message}");
                }
                throw; // Re-lanzamos la excepción para que la función Lambda la maneje
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[ERROR] Error al procesar JSON: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error inesperado: {ex.Message}");
                Console.WriteLine($"[ERROR] Stack Trace: {ex.StackTrace}");
                throw;
            }
            throw new NotImplementedException();
        }


    }
}
