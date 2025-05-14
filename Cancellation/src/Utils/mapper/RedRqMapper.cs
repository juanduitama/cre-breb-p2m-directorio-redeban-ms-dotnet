using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Cancellation_Service.Domain.models.redeban;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.models.openSearchModel;
using SPI_Cancellation_Service.Domain.models.oAuth;

namespace SPI_Cancellation_Service.Utils.mapper
{
    /// <summary>
    /// Utilidad para manejar encabezados HTTP
    /// </summary>
    public class RedRqMapper
    {

        private static readonly Random random = new Random();

        public RedRqMapper()
        {

        }

        public void AddDeleteHeaders(HttpClient request, HeadersRq headers, string token)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE, headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.DATE, headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RBM_FROM, headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ACCEPT, headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_FORWARDED_FOR, headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_REQUEST_ID, Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ORIGIN, ConstantsEnum.ORIGIN);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RQ_ID, random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.AUTHORIZATION, ConstantsEnum.BEARER + " " + token.Trim());
            Console.WriteLine("Estos son los headers para http");

            Console.WriteLine(request.DefaultRequestHeaders.ToString());
        }

        //Cabeceras de OS a Redeban
        public HeadersRq MapHeadersFromRequest(DeleteHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = headersRq.timeStamps.Replace("Z", "");
            
            headersRed.Date = newDate;
            headersRed.ContentType = ConstantsEnum.APPLICATION_JSON;
            headersRed.Accept = ConstantsEnum.APPLICATION_JSON;
            headersRed.Origin = RedHeadersEnum.ORIGIN;
            headersRed.XForwardedFor = ConstantsEnum.IP_ORIGIN;
            headersRed.XRequestId = headersRq.uuId;
            headersRed.RBMFrom = ConstantsEnum.RBM_FROM;

            return headersRed;

        }
        
        public  DeleteRq MapBodyFromRequest(ReqBPutKey body, OSDefinitive osEntity) 
        {
            DeleteRq bodyRed = new DeleteRq();

          string newDate = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.SSS");

          bodyRed.requestDateTime = newDate;
          bodyRed.keyStatus = body.key.keyStatus;
          //bodyRed.documentType = osEntity.custInfoOS.custIdent.custIdentType;
          bodyRed.documentType = "NIT";
          //bodyRed.documentNumber = osEntity.custInfoOS.custIdent.custIdentId;
          bodyRed.documentNumber = "123456789";
          bodyRed.merchantId = "0012345678";

          return bodyRed;


        }

        public void addOauthHeaders(HttpClient request)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE, ConstantsEnum.APPLICATION_URL_ENCODE);
            //request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_ID, ConstantsEnum.IBM_CLIENT_ID);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_ID, Environment.GetEnvironmentVariable(ConstantsEnum.IBM_CLIENT_ID));
            //request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_SECRET, ConstantsEnum.IBM_Client_Secret);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_SECRET, Environment.GetEnvironmentVariable(ConstantsEnum.IBM_Client_Secret));
        }

        public RqOAuth mapBodyOauth()
        {
            RqOAuth rqOauth = new RqOAuth();
            rqOauth.scopes = ConstantsEnum.SCOPES;
            rqOauth.grantType = ConstantsEnum.GRANTYPE;
            return rqOauth;
        }



    }

}
