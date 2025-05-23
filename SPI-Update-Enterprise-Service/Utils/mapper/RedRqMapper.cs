using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Domain.models.redeban;
using SPI_Update_Enterprise_Service.Domain.models.updateEnterprise;
using SPI_Cancellation_Service.Domain.models.oAuth;
using SPI_Update_Enterprise_Service.Utils.util;
using SPI_Update_Enterprise_Service.Domain.models;

namespace SPI_Update_Enterprise_Service.Utils.mapper
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
        public HeadersRq MapHeadersFromRequest(UpdateHeadersEnterprise headersRq)
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
        public UpdateRqRed MapBodyFromRequest(ReqBPatchEnterprise body, UpdateHeadersEnterprise updateHeadersEnterprise)
        {
            UpdateRqRed bodyRed = new UpdateRqRed();

            bodyRed.requestDateTime = updateHeadersEnterprise.timeStamps;
            bodyRed.documentNumber = body.entInfo.entIdent.entIdentId;
            bodyRed.nameEnterprise = body.entInfo.nameEnterprise;

            LegalRepresentative legalRepresentative = new LegalRepresentative();
            legalRepresentative.name = body.legalInfo.nameRl;
            legalRepresentative.documentType = body.legalInfo.entIdentRl.entIdentType;
            legalRepresentative.documentNumber = body.legalInfo.entIdentRl.entIdentId;
            if (!string.IsNullOrWhiteSpace(body.legalInfo.email))
            {
                legalRepresentative.email = body.legalInfo.email;
            }

            legalRepresentative.mobileNumber = body.legalInfo.mobileNumber;

            string documentIssuanceDate = body.legalInfo.documentIssuanceDate.ToString("dddd-MM-dd");

            if (!string.IsNullOrWhiteSpace(documentIssuanceDate))
            {
                legalRepresentative.docummentIssuanceDate = body.legalInfo.documentIssuanceDate;
            }

            bodyRed.legalRepresentative = legalRepresentative;


            EnterpriseContact enterpriseContact = new EnterpriseContact();
            EntPostalAddress entPostalAddress = new EntPostalAddress();
            entPostalAddress.address = body.entInfo.entContact.address;
            entPostalAddress.daneCode = body.entInfo.entContact.daneCode;

            if (!string.IsNullOrWhiteSpace(body.entInfo.entContact.twonName))
            {
                entPostalAddress.twonName = body.entInfo.entContact.twonName;
            }
            entPostalAddress.country = body.entInfo.entContact.country;
            enterpriseContact.postalAddress = entPostalAddress;

            bodyRed.enterpriseContact = enterpriseContact;


            CommerceRed commerce = new CommerceRed();
            commerce.nameCommerce = body.commerce.nameCommerce;
            if(!string.IsNullOrWhiteSpace(body.commerce.alias))
            {
                commerce.alias = body.commerce.alias;
            }
            
            EntPostalAddress entPostalAddressCommerce = new EntPostalAddress();
            entPostalAddressCommerce.address = body.commerce.entCommerceContact.address;
            entPostalAddressCommerce.daneCode = body.commerce.entCommerceContact.daneCode;

            if (!string.IsNullOrWhiteSpace(body.commerce.entCommerceContact.twonName))
            {
                entPostalAddressCommerce.twonName = body.commerce.entCommerceContact.twonName;
            }
            entPostalAddressCommerce.country = body.commerce.entCommerceContact.country;

            commerce.entPostalAddress = entPostalAddressCommerce;
            bodyRed.commerce = commerce;

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
