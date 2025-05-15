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
    public enum StatusCodeEnum
    {
        PERSON_SUCCESS_STATUS_CODE,
        RED_PERSON_SUCCESS_STATUS_CODE,
        PERSON_CREATED_STATUS_CODE,
        RED_PERSON_CREATED_STATUS_CODE,
    }
        public static class StatusCodeEnumExtensions
    {
            public static string getValue(this StatusCodeEnum statusCodeEnum)
            {
                return statusCodeEnum switch
                {
                    StatusCodeEnum.PERSON_SUCCESS_STATUS_CODE => "200",
                    StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE => "NT00",
                    StatusCodeEnum.PERSON_CREATED_STATUS_CODE => "201",
                    StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE => "U000",
        _ => throw new ArgumentOutOfRangeException(nameof(statusCodeEnum))
                };
            }
        }
}
