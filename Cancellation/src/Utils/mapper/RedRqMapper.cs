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
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.CONTENT_TYPE.getKeyHeader(), headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.DATE.getKeyHeader(), headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.RBM_FROM.getKeyHeader(), headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.ACCEPT.getKeyHeader(), headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_FORWARDED_FOR.getKeyHeader(), headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_REQUEST_ID.getKeyHeader(), headers.XRequestId);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.ORIGIN.getKeyHeader(), ConstantsEnums.ORIGIN.getValue());
            //request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.RQ_ID.getKeyHeader(), random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.AUTHORIZATION.getKeyHeader(), ConstantsEnums.BEARER.getValue() + " " + token.Trim());
            Console.WriteLine("Estos son los headers para http");

            Console.WriteLine(request.DefaultRequestHeaders.ToString());
        }

        //Cabeceras de OS a Redeban
        public HeadersRq MapHeadersFromRequest(DeleteHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = headersRq.timeStamps.Replace("Z", "");
            
            headersRed.Date = newDate;
            headersRed.ContentType = ConstantsEnums.APPLICATION_JSON.getValue();
            headersRed.Accept = ConstantsEnums.APPLICATION_JSON.getValue();
            headersRed.Origin = RedHeadersEnums.ORIGIN.getKeyHeader();
            headersRed.XForwardedFor = headersRq.ipOrigin;
            headersRed.XRequestId = headersRq.uuId;
            headersRed.RBMFrom = ConstantsEnums.RBM_FROM.getValue();

            return headersRed;

        }
        public DeleteRq MapBodyFromRequest(ReqBPutKey body, DeleteHeaders deleteHeaders)
        {
            DeleteRq bodyRed = new DeleteRq();

            //string newDate = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff");

            bodyRed.requestDateTime = deleteHeaders.timeStamps;
            bodyRed.keyStatus = body.key.keyStatus;
            //bodyRed.documentType = osEntity.custInfoOS.custIdent.custIdentType;
            bodyRed.documentType = body.custIdent.custIdentType;
            //bodyRed.documentNumber = osEntity.custInfoOS.custIdent.custIdentId;
            bodyRed.documentNumber = body.custIdent.custIdentId;
            if (!string.IsNullOrEmpty(body.merchantId))
            {
                bodyRed.merchantId = body.merchantId;
            }

            bodyRed.keyObservation = string.IsNullOrEmpty(body.keyObservation) ?  null : body.keyObservation;

            return bodyRed;


        }

        public void addOauthHeaders(HttpClient request)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.CONTENT_TYPE.getKeyHeader(), ConstantsEnums.APPLICATION_URL_ENCODE.getValue());
            //request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_IBM_CLIENT_ID.getKeyHeader(), Environment.GetEnvironmentVariable(ConstantsEnums.IBM_CLIENT_ID.getValue()));
            //request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_IBM_CLIENT_SECRET.getKeyHeader(), Environment.GetEnvironmentVariable(ConstantsEnums.IBM_CLIENT_SECRET.getValue()));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_IBM_CLIENT_ID.getKeyHeader(), ConstantsEnums.IBM_CLIENT_ID.getValue());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnums.X_IBM_CLIENT_SECRET.getKeyHeader(), ConstantsEnums.IBM_CLIENT_SECRET.getValue());
        }

        public RqOAuth mapBodyOauth()
        {
            RqOAuth rqOauth = new RqOAuth();
            rqOauth.scopes = ConstantsEnums.SCOPES.getValue();
            rqOauth.grantType = ConstantsEnums.GRANTYPE.getValue();
            return rqOauth;
        }



    }

}
