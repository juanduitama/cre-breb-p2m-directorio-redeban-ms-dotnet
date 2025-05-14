using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
{
    /// <summary>
    /// ConstantsEnum define los valores de constantes utilizadas
    /// 
    /// Desarrollo 
    /// 
    /// Requerimiento:
    /// </summary>
    public static class ConstantsEnum
    {
        public const string APPLICATION_JSON = "application/json";
        public const string APPLICATION_URL_ENCODE = "application/x-www-form-urlencoded";
        public const string TYPE_PERSON = "PERSON";
        public const string ORIGIN = "origin";
        public const string TYPE_COMMERCE = "COMMERCE";
        public const string OAUTH_TOKEN = "TOKEN";
        public const string BEARER = "Bearer";
        public const string IP_ORIGIN = "10.415.16.2";
        public const string RBM_FROM = "65a4a028-7b29-44d0-878c-03a479f8a23d";

        public const string IBM_CLIENT_ID = "54cfb091cdd1c1f30f9cb3423a28aebe";
        public const string IBM_Client_Secret = "c92296aaeeb1965330c077e1a8f73889";

        public const string SCOPES = "HUB";
        public const string GRANTYPE = "client_credentials";


        public const string BASE_URI = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/";
        public const string DELETE_URI = "keyType/{keyType}/key/{keyValue}";
        public const string BASE_URI_OAUTH = "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token";

    }
}
