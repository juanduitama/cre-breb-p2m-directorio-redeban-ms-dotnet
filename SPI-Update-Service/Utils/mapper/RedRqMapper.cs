using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban;
using SPI_Update_Service.domain.models.redeban;
using domain.models.oAuth;
using Microsoft.VisualBasic;
using SPI_Update_Service.Domain.models.redeban;

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
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.X_REQUEST_ID.getValue(), headers.XRequestId);
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.ORIGIN.getValue(), ConstantsEnum.ORIGIN.getValue());
            request.DefaultRequestHeaders.TryAddWithoutValidation(RedHeadersEnum.AUTHORIZATION.getValue(), ConstantsEnum.BEARER.getValue() + " " + token.Trim());
            Console.WriteLine("Estos son los headers para http: " + request.DefaultRequestHeaders.ToString());

        }

        public HeadersRq MapHeadersFromRequest(UpdateHeaders headersRq)
        {
            HeadersRq headersRed = new HeadersRq();

            string newDate = DateTime.Now.ToString(ValidationEnums.DATE_FORMAT).Replace("Z", ""); 

            headersRed.Date = newDate;
            headersRed.ContentType = ConstantsEnum.APPLICATION_JSON.getValue();
            headersRed.Accept = ConstantsEnum.APPLICATION_JSON.getValue();
            headersRed.Origin = RedHeadersEnum.ORIGIN.getValue();
            headersRed.XForwardedFor = headersRq.ipOrigin;
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

        public UpdateAcctRq MapBodyAccountFromRequest(ReqBPatchAccount reqBPatchAccount, UpdateHeaders headersRq)
        {
            UpdateAcctRq bodyRed = new UpdateAcctRq();

            bodyRed.requestDateTime = headersRq.timeStamp;

            Customer customer = new Customer();
            customer.type = reqBPatchAccount.custInfo.custType;

            bodyRed.customer = customer;

            if (reqBPatchAccount.custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PN)) {
                Person person = new Person();
                person.firstName = reqBPatchAccount.custInfo.firstName;
                person.middleName = reqBPatchAccount.custInfo.secondName;
                person.firstSurName = reqBPatchAccount.custInfo.lastName;
                person.middleSurName = reqBPatchAccount.custInfo.secondLastName;

                PersonContact contact = new PersonContact();
                contact.mobileNumber = ConstantsEnum.COUNTRY_CODE.getValue()+ reqBPatchAccount.custInfo.custContact.custMobileNumber;

                person.personContact = contact;

                person.documentType = reqBPatchAccount.custInfo.custIdent.custIdentType;
                person.documentNumber = reqBPatchAccount.custInfo.custIdent.custIdentId;

                bodyRed.customer.person = person;
            }

            Account account = new Account();

            //account.typeAccount = reqBPatchAccount.acctInfo.newAcctType != null ? reqBPatchAccount.acctInfo.newAcctType : osOldDefinitive.acctInfo.acctType;
            //account.accountNo = reqBPatchAccount.acctInfo.newAcctId != null ? reqBPatchAccount.acctInfo.newAcctId : osOldDefinitive.acctInfo.acctId;
            //account.ageAccount = reqBPatchAccount.acctInfo.ageAccount != null ? reqBPatchAccount.acctInfo.ageAccount : osOldDefinitive.acctInfo.ageAccount;

            account.typeAccount = reqBPatchAccount.acctInfo.newAcctType;
            account.accountNo = reqBPatchAccount.acctInfo.newAcctId;
            account.ageAccount = reqBPatchAccount.acctInfo.ageAccount;

            Product product = new Product();

            product.account = account;

            bodyRed.product = product;


            return bodyRed;
        }

        public UpdateKeyPersonRq MapBodyKeyFromRequest(UpdateKeyRq request)
        {

            UpdateKeyPersonRq bodyRed = new UpdateKeyPersonRq();

            bodyRed.requestDateTime = request.updateHeaders.timeStamp;
            bodyRed.partySystemIdentifier = request.reqBPatchKey.key.oldKeyType;
            bodyRed.partyIdentifier = request.reqBPatchKey.key.oldKeyId;
            bodyRed.newPartySystemIdentifier = request.reqBPatchKey.key.newKeyType;
            bodyRed.newPartyIdentifier = request.reqBPatchKey.key.newKeyId;

            return bodyRed;


        }


    }

}
