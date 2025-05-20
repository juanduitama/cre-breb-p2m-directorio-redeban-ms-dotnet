using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{

    public enum ResponseEnun
    {
        UPDATE_RESPONSE_CODE_SUCCESS,
        UPDATE_RESPONSE_DESC_SUCCESS_PRODUCT,
        UPDATE_RESPONSE_DESC_SUCCESS_KEY,
        UPDATE_BAD_RESPONSE_CODE,
    }
    public static class ResponseEnunExtensions
    {

        public static string getValue(this ResponseEnun responseEnum)
        {
            return responseEnum switch
            {
                ResponseEnun.UPDATE_RESPONSE_CODE_SUCCESS => "201",
                ResponseEnun.UPDATE_RESPONSE_DESC_SUCCESS_PRODUCT => "El producto se modificó exitosamente",
                ResponseEnun.UPDATE_RESPONSE_DESC_SUCCESS_KEY => "La llave se modificó exitosamente",
                ResponseEnun.UPDATE_BAD_RESPONSE_CODE => "500",

                _ => throw new ArgumentOutOfRangeException(nameof(responseEnum))
            };

        }
    }
}
