using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
{
    /// <summary>
    /// HeadersEnum define los valores para los encabezados
    /// </summary>
    /// 

    public enum RedHeadersEnums
    {
        AUTHORIZATION,
        CONTENT_TYPE,
        DATE,
        X_FORWARDED_FOR,
        RBM_FROM,
        ACCEPT,
        X_REQUEST_ID,
        ORIGIN,
        RQ_ID,
        X_IBM_CLIENT_ID,
        X_IBM_CLIENT_SECRET
    }
    public static class RedHeadersEnumExtensions
    {

        public static string getKeyHeader(this RedHeadersEnums redHeadersEnums)
        {
            return redHeadersEnums switch
            {
                RedHeadersEnums.CONTENT_TYPE => "Content-Type",
                RedHeadersEnums.DATE => "Date",
                RedHeadersEnums.RBM_FROM => "RBM-FROM",
                RedHeadersEnums.ACCEPT => "Accept",
                RedHeadersEnums.X_FORWARDED_FOR => "X-Forwarded-For",
                RedHeadersEnums.X_REQUEST_ID => "X-Request-ID",
                RedHeadersEnums.ORIGIN => "Origin",
                RedHeadersEnums.RQ_ID => "RqId",
                RedHeadersEnums.AUTHORIZATION => "Authorization",
                RedHeadersEnums.X_IBM_CLIENT_ID => "X-IBM-Client-Id",
                RedHeadersEnums.X_IBM_CLIENT_SECRET => "X-IBM-Client-Secret",
                _=> throw new ArgumentOutOfRangeException(nameof(redHeadersEnums))
            };
        }
    }
}
