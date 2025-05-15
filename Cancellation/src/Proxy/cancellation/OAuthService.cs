using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.oAuth;
using SPI_Cancellation_Service.Proxy.interfaces;
using SPI_Cancellation_Service.Utils.mapper;
using SPI_Cancellation_Service.Utils.util;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SPI_Cancellation_Service.Proxy.cancellation
{
    public class OAuthService : IOAuthService
    {

        private readonly RedRqMapper redMapper = new RedRqMapper();


        public OAuthService()
        {

        }



        public async Task<bool> validateToken(string token)
        {
            return false;
        }

        public async Task<RsOAuth> getToken(string url, HttpClient _httpClient)
        {

            Console.WriteLine($"Comienza obtención de token \n url: {url}");

            _httpClient.DefaultRequestHeaders.Clear();
            // Agregar cabeceras HTTP necesarias
            redMapper.addOauthHeaders(_httpClient);
            RqOAuth rqOauth = redMapper.mapBodyOauth();

            RsOAuth responseOAuth = new RsOAuth();

            // CAMBIO: En lugar de JSON, crear URL-encoded form data
            var formData = ConvertToFormData(rqOauth);
            var content = new FormUrlEncodedContent(formData);

            // Asegurarse de que el Content-Type es correcto
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ConstantsEnums.APPLICATION_URL_ENCODE.getValue());

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseRes = await response.Content.ReadAsStringAsync();

            responseOAuth = UtilCommons.String2Object<RsOAuth>(responseRes);

            string responseOAuthS = UtilCommons.Object2String(responseRes);

            Console.WriteLine($"[RES] Respuesta:" + responseOAuthS);

            return responseOAuth;
        }



        private Dictionary<string, string> ConvertToFormData(RqOAuth rqOAuth)
        {
            var formData = new Dictionary<string, string>();

            if (rqOAuth != null)
            {
                formData.Add("grant_type", "client_credentials");

                formData.Add("data", JsonSerializer.Serialize(rqOAuth));

            }

            return formData;
        }
    }
    
}
