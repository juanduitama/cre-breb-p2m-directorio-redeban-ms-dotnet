using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
{
    public enum ResponseEnums
    {
        ENRROLLMENT_RESPONSE_SUCCESS,
    }
    public static class ResponseEnum
    {

        public static string getResponseCode(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                 ResponseEnums.ENRROLLMENT_RESPONSE_SUCCESS => "201",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

        public static string getResponseMessage(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                ResponseEnums.ENRROLLMENT_RESPONSE_SUCCESS => "La llave se creo exitosamente",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

    }
}
