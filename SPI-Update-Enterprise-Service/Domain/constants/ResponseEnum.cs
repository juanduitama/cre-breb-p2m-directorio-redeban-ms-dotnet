using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Update_Enterprise_Service.Domain.constants
{
    public enum ResponseEnums
    {
        UPDATE_RESPONSE_SUCCESS,
        UPDATE_RESPONSE_BAD_REQUEST,
        UPDATE_RESPONSE_ERROR,
    }
    public static class ResponseEnum
    {

        public static string getResponseCode(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                 ResponseEnums.UPDATE_RESPONSE_SUCCESS => "201",
                 ResponseEnums.UPDATE_RESPONSE_BAD_REQUEST => "400",
                 ResponseEnums.UPDATE_RESPONSE_ERROR => "500",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

        public static string getResponseMessage(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                ResponseEnums.UPDATE_RESPONSE_SUCCESS => "La llave se cancelo exitosamente",
                ResponseEnums.UPDATE_RESPONSE_BAD_REQUEST => "Error en el microservicio",
                ResponseEnums.UPDATE_RESPONSE_ERROR => "Error al cancelar la llave",
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

        public static int getHttpCode(this ResponseEnums responseEnums)
        {
            return responseEnums switch
            {
                ResponseEnums.UPDATE_RESPONSE_SUCCESS => 201,
                ResponseEnums.UPDATE_RESPONSE_BAD_REQUEST => 400,
                ResponseEnums.UPDATE_RESPONSE_ERROR => 500,
                _ => throw new ArgumentOutOfRangeException(nameof(responseEnums))
            };
        }

    }
}
