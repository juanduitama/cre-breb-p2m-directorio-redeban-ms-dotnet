using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{
    /// <summary>
    /// ConstantsEnum define los valores de constantes utilizadas
    /// 
    /// Desarrollo 
    /// 
    /// Requerimiento:
    /// </summary>
    public enum ConstantsEnum
    {
        APPLICATION_JSON,
        APPLICATION_URL_ENCODE,
        ORIGIN,
        IP_ORIGIN,
        RBM_FROM,
        IBM_CLIENT_ID,
        IBM_ClientSecret,
        CERTIFICATE,
        BEARER,

        SCOPES,
        GRANTYPE,

        BASE_URI_OAUTH,
        BASE_URI_ACCOUNT,
        BASE_URI_KEY,
        KEY_VALUE_PATH,
        KEY_TYPE_PATH,
        KEY_ID_PATH,

        COUNTRY_CODE,

        TYPE_KEY_ID,
        TYPE_OLD_KEY_ID,
        TYPE_NEW_KEY_ID
    }

        public static class ConstantsEnumExtensions
        {
            /// <summary>
            /// Obtiene el código de estado HTTP
            /// </summary>
            public static string getValue(this ConstantsEnum constantsEnum)
            {
                return constantsEnum switch
                {
                    ConstantsEnum.APPLICATION_JSON => "application/json",
                    ConstantsEnum.APPLICATION_URL_ENCODE => "application/x-www-form-urlencoded",
                    ConstantsEnum.ORIGIN => "origin",
                    ConstantsEnum.IP_ORIGIN => "10.415.16.2",
                    ConstantsEnum.RBM_FROM => "65a4a028-7b29-44d0-878c-03a479f8a23d",
                    ConstantsEnum.IBM_CLIENT_ID => "IBM_CLIENT_ID",
                    ConstantsEnum.IBM_ClientSecret => "IBM_ClientSecret",
                    ConstantsEnum.CERTIFICATE => "CERTIFICATE",
                    ConstantsEnum.BEARER => "Bearer",
                    ConstantsEnum.SCOPES => "HUB",
                    ConstantsEnum.GRANTYPE => "client_credentials",
                    ConstantsEnum.BASE_URI_OAUTH => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token",
                    ConstantsEnum.BASE_URI_ACCOUNT => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/keytype/" + ConstantsEnum.KEY_TYPE_PATH.getValue() + "/key/" + ConstantsEnum.KEY_VALUE_PATH.getValue(),
                    ConstantsEnum.BASE_URI_KEY => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/key/" + ConstantsEnum.KEY_ID_PATH.getValue(),
                    ConstantsEnum.KEY_VALUE_PATH => "{keyValue}",
                    ConstantsEnum.KEY_TYPE_PATH => "{keyType}",
                    ConstantsEnum.KEY_ID_PATH => "{ID}",
                    ConstantsEnum.COUNTRY_CODE => "+57",
                    _ => throw new ArgumentOutOfRangeException(nameof(constantsEnum))
                };
            }

        public static int getId(this ConstantsEnum constantsEnum)
        {
            return constantsEnum switch
            {
                ConstantsEnum.TYPE_KEY_ID => 0,
                ConstantsEnum.TYPE_OLD_KEY_ID => 1,
                ConstantsEnum.TYPE_NEW_KEY_ID => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(constantsEnum))
            };
        }
    }

}
