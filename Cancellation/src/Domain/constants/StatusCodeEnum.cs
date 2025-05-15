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

    public enum StatusCodeEnums
    {
        /// <summary>
        /// Constante de error en caso de que se presente un fallo al intentar operación sobre DynamoDB.
        /// </summary>
        RED_PERSON_SUCCESS,
        RED_PERSON_CREATED,
    }
    public static class StatusCodeEnumsExtensions
    {
        /// <summary>
        /// Obtiene el código de estado HTTP
        /// </summary>
        public static string getStatusCode(this StatusCodeEnums statusCode)
        {
            return statusCode switch
            {
                StatusCodeEnums.RED_PERSON_SUCCESS => "NT00",
                StatusCodeEnums.RED_PERSON_CREATED => "U000",
                _ => throw new ArgumentOutOfRangeException(nameof(statusCode))
            };
        }
    }
}
