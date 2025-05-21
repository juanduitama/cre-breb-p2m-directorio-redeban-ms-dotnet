
using System.Text;

using System.Text.Json;
using domain.models.redeban;

using SPI_Update_Service.domain.models.redeban;
using domain.constants;
using domain.models.redeban.response;
using domain.models.oAuth;

using SPI_Update_Service.Proxy.interfaces;
using SPI_Update_Service.Utils.util;
using SPI_Update_Service.Utils.mapper;
using SPI_Update_Service.ApplicationCore.services;

namespace SPI_Update_Service.Proxy.update
{
    public class RedUpdateServiceImpl : IRedUpdateService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private HttpClient _httpClient;
        
        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private readonly BuilderHttpUtil _BuilderHttpUtil;
        private readonly RedRqMapper redMapper;

        private readonly IOauthServices _oauthService = new OAuthService();

        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedUpdateServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();

            redMapper = new RedRqMapper();

        }

        public async Task<MsgInformationResponse> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq requestBody)
        {
            try
            {

                MsgInformationResponse responseRedebanAccount = new MsgInformationResponse();

                _httpClient = _BuilderHttpUtil.BuildClientWithClientCertificate();

                _httpClient.DefaultRequestHeaders.Clear();

                RsOAuth responseOauthAccount = await _oauthService.getToken(Environment.GetEnvironmentVariable(ConstantsEnum.BASE_URI_OAUTH.getValue()), _httpClient);

                Console.WriteLine("Token para cuenta obtenido Oauth: " + responseOauthAccount.accessToken);

                Console.WriteLine($"[INFO] Iniciando solicitud PATCH Update account a: {url}");
                _httpClient.DefaultRequestHeaders.Clear();

                redMapper.AddUpdateHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] body a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON.getValue());

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PATCH...");

                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);

                string responseRes = await response.Content.ReadAsStringAsync();

                responseRedeban = UtilCommons.String2Object<MsgInformationResponse>(responseRes);

                Console.WriteLine($"[RES] Respuesta: {responseRes}");

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
        }

        public async Task<MsgInformationResponse> UpdateKeyAsync(string url, HeadersRq headers, UpdateKeyPersonRq requestBody)
        {
            try
            {
                MsgInformationResponse responseRedeban = new MsgInformationResponse();

                _httpClient = _BuilderHttpUtil.BuildClientWithClientCertificate();

                _httpClient.DefaultRequestHeaders.Clear();
                RsOAuth responseOauth = await _oauthService.getToken(ConstantsEnum.BASE_URI_OAUTH.getValue(), _httpClient);
                
                Console.WriteLine("Token obtenido Oauth: " + responseOauth.accessToken);
                
                Console.WriteLine($"[INFO] Iniciando solicitud PATCH Update key a: {url}");

                _httpClient.DefaultRequestHeaders.Clear();

                redMapper.AddUpdateHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON.getValue());

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PATCH...");

                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);
                
                string responseRes = await response.Content.ReadAsStringAsync();

                responseRedeban = UtilCommons.String2Object<MsgInformationResponse>(responseRes);

                Console.WriteLine($"[RES] Respuesta: {responseRes}");

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
        }
    }
}
