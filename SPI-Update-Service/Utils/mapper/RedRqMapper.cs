using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban;
using SPI_Update_Service.domain.models.redeban;
using domain.models.oAuth;
using Microsoft.VisualBasic;

namespace SPI_Update_Service.Utils.mapper
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

        public void AddUpdateHeaders(HttpClient request, HeadersRq headers, string token)
        {

            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE.getValue(), headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.DATE.getValue(), headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.RBM_FROM.getValue(), headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ACCEPT.getValue(), headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_FORWARDED_FOR.getValue(), headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_REQUEST_ID.getValue(), Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ORIGIN.getValue(), ConstantsEnum.ORIGIN.getValue());
            Console.WriteLine("Estos son los headers para http: " + request.DefaultRequestHeaders.ToString());

        }

        //Cabeceras de OS a Redeban
        public HeadersRq MapHeadersFromRequest(UpdateHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = headersRq.timeStamps.Replace("Z", "");

            headersRed.Date = newDate;
            headersRed.ContentType = ConstantsEnum.APPLICATION_JSON.getValue();
            headersRed.Accept = ConstantsEnum.APPLICATION_JSON.getValue();
            headersRed.Origin = RedHeadersEnum.ORIGIN.getValue();
            headersRed.XForwardedFor = ConstantsEnum.IP_ORIGIN.getValue();
            headersRed.XRequestId = headersRq.uuId;
            headersRed.RBMFrom = ConstantsEnum.RBM_FROM.getValue();

            return headersRed;

        }

        public void addOauthHeaders(HttpClient request)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.CONTENT_TYPE.getValue(), ConstantsEnum.APPLICATION_URL_ENCODE.getValue());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_ID.getValue(), Environment.GetEnvironmentVariable(ConstantsEnum.IBM_CLIENT_ID.getValue()));
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_IBM_CLIENT_SECRET.getValue(), Environment.GetEnvironmentVariable(ConstantsEnum.IBM_ClientSecret.getValue()));
        }


        public RqOAuth mapBodyOauth()
        {
            RqOAuth rqOauth = new RqOAuth();
            rqOauth.scopes = ConstantsEnum.SCOPES.getValue();
            rqOauth.grantType = ConstantsEnum.GRANTYPE.getValue();
            return rqOauth;
        }

        public UpdateAcctRq MapBodyAccountFromRequest(ReqBPatchAccount reqBPatchAccount)
        {
            UpdateAcctRq bodyRed = new UpdateAcctRq();


            bodyRed.requestDateTime = DateTime.Now.ToString(ValidationEnums.DATE_FORMAT);

            Customer customer = new Customer();
            customer.type = reqBPatchAccount.custInfo.custType;

            bodyRed.customer = customer;

            Account account = new Account();

            //account.typeAccount = reqBPatchAccount.acctInfo.newAcctType != null ? reqBPatchAccount.acctInfo.newAcctType : osOldDefinitive.acctInfo.acctType;
            //account.accountNo = reqBPatchAccount.acctInfo.newAcctId != null ? reqBPatchAccount.acctInfo.newAcctId : osOldDefinitive.acctInfo.acctId;
            //account.ageAccount = reqBPatchAccount.acctInfo.ageAccount != null ? reqBPatchAccount.acctInfo.ageAccount : osOldDefinitive.acctInfo.ageAccount;

            account.typeAccount = reqBPatchAccount.acctInfo.newAcctType != null ? reqBPatchAccount.acctInfo.newAcctType : reqBPatchAccount.acctInfo.oldAcctType;
            account.accountNo = reqBPatchAccount.acctInfo.newAcctId != null ? reqBPatchAccount.acctInfo.newAcctId : reqBPatchAccount.acctInfo.oldAcctId;
            account.ageAccount = reqBPatchAccount.acctInfo.ageAccount;

            Product product = new Product();

            product.account = account;

            bodyRed.product = product;


            return bodyRed;
        }



    }

}
