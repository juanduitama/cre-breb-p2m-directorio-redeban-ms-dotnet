using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{
    /// <summary>
    /// HeadersEnum define los valores para los encabezados
    /// </summary>
    public enum RedHeadersEnum
    {
        CONTENT_TYPE,
        DATE,
        RBM_FROM,
        ACCEPT,
        X_FORWARDED_FOR,
        X_REQUEST_ID,
        ORIGIN,
        X_IBM_CLIENT_ID,
        X_IBM_CLIENT_SECRET,
     }

     public static class RedHeadersEnumExtensions
     {

        public static string getValue(this RedHeadersEnum redHeadersEnum)
        {
        return redHeadersEnum switch
        {
            RedHeadersEnum.CONTENT_TYPE => "Content-Type",
            RedHeadersEnum.DATE => "Date",
            RedHeadersEnum.RBM_FROM => "RBM-FROM",
            RedHeadersEnum.ACCEPT => "Accept",
            RedHeadersEnum.X_FORWARDED_FOR => "X-Forwarded-For",
            RedHeadersEnum.X_REQUEST_ID => "X-Request-ID",
            RedHeadersEnum.ORIGIN => "Origin",
            RedHeadersEnum.X_IBM_CLIENT_ID => "X-IBM-Client-Id",
            RedHeadersEnum.X_IBM_CLIENT_SECRET => "X-IBM-Client-Secret",

            _ => throw new ArgumentOutOfRangeException(nameof(redHeadersEnum))
        };
        
        }
    }
}
