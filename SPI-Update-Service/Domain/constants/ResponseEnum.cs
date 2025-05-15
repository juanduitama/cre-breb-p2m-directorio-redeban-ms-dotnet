using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{

    public enum ResponseEnun
    {
        ENRROLLMENT_RESPONSE_CODE_SUCCESS,
        ENRROLLMENT_RESPONSE_DESC_SUCCESS,

    }
    public static class ResponseEnunExtensions
    {

        public static string getValue(this ResponseEnun responseEnum)
        {
            return responseEnum switch
            {
                ResponseEnun.ENRROLLMENT_RESPONSE_CODE_SUCCESS => "201",
                ResponseEnun.ENRROLLMENT_RESPONSE_DESC_SUCCESS => "La llave se modificó exitosamente",

                _ => throw new ArgumentOutOfRangeException(nameof(responseEnum))
            };

        }
    }
}
