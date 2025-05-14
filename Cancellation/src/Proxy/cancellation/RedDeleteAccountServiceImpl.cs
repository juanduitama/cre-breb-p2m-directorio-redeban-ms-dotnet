using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.oAuth;
using SPI_Cancellation_Service.Domain.models.redeban;
using SPI_Cancellation_Service.Domain.models.redeban.response;
using SPI_Cancellation_Service.Proxy.interfaces;
using SPI_Cancellation_Service.Utils.mapper;
using SPI_Cancellation_Service.Utils.util;


namespace SPI_Cancellation_Service.Proxy.cancellation
{
    public class RedDeleteAccountServiceImpl : IRedDeleteAccountService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private  readonly HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private  readonly BuilderHttpUtil _BuilderHttpUtil;

        /// <summary>
        /// 
        /// </summary>
        private  readonly RedRqMapper _redRqMapper = new RedRqMapper();

        /// <summary>
        /// 
        /// </summary>
        private readonly IOAuthService _oauthService = new OAuthService();



        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedDeleteAccountServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClientWithServerCertificate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MsgInformationResponse> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq requestBody)
        {
            try
            {
                MsgInformationResponse responseRedeban = new MsgInformationResponse();

                Console.WriteLine($"[INFO] Iniciando solicitud PUT Cancelacion a: {url}");

                ClearHeaders();

                RsOAuth responseOauth = await _oauthService.getToken(ConstantsEnum.BASE_URI_OAUTH, _httpClient);

                Console.WriteLine("Token obtenido Oauth: " + responseOauth.accessToken);

                ClearHeaders();

                //Agregar cabeceras HTTP necesarias
                _redRqMapper.AddDeleteHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PUT...");
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[WARN] Respuesta de error: {responseContent}");

                responseRedeban = await UtilCommons.String2Object<MsgInformationResponse>(responseContent);

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

        /// <summary>
        /// Limpia todas las cabeceras HTTP predeterminadas del cliente HTTP.
        /// </summary>
        /// <remarks>
        /// Este método se utiliza para evitar la acumulación de cabeceras duplicadas
        /// entre llamadas consecutivas utilizando el mismo cliente HTTP.
        /// </remarks>
        private void ClearHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }
    }
}
