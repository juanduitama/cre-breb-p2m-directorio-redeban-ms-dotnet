using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
{
    public enum ResponseEnums
    {
        CANCELLATION_RESPONSE_SUCCESS,
        CANCELLATION_RESPONSE_ERROR,
    }
    public static class ResponseEnum
    {

        public static string getResponseCode(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                 ResponseEnums.CANCELLATION_RESPONSE_SUCCESS => "201",
                    ResponseEnums.CANCELLATION_RESPONSE_ERROR => "500",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

        public static string getResponseMessage(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                ResponseEnums.CANCELLATION_RESPONSE_SUCCESS => "La llave se cancelo exitosamente",
                ResponseEnums.CANCELLATION_RESPONSE_ERROR => "Error al cancelar la llave",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

    }
}
