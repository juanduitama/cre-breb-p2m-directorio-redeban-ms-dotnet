using System;
using System.Collections.Generic;
using SPI_Update_Enterprise_Service.Domain.constants;

namespace SPI_Update_Enterprise_Service.Utils.util
{
    public class UriUtil
    {


        public UriUtil()
        {           
        }

        /// <summary>
        /// Construye una URI para consultas basada en el tipo de operación y parámetros de ruta
        /// </summary>
        /// <param name="methodDescription">Tipo de operación según las constantes definidas</param>
        /// <param name="routeValues">Diccionario con los valores de ruta</param>
        /// <returns>URI completa para la operación</returns>
        public string BuildUri(string merchantId)
        {
            //string newUri = getValuePathParameters(Environment.GetEnvironmentVariable(ConstantsEnums.BASE_URI_CANCELLATION.getValue()), PathParametersEnums.KEY_TYPE, keyType);
            string newUri = getValuePathParameters(ConstantsEnums.BASE_URI_UPDATE_ENTERPRISE.getValue(), PathParametersEnums.MERCHANT_ID, merchantId);

            return newUri;                
            
        }


        private string getValuePathParameters(string uri, PathParametersEnums pathParameter, string valueParameter)
        {
            if (uri.Contains(pathParameter.getValuePathParameters()))
            {
                return uri.Replace(pathParameter.getValuePathParameters(), valueParameter);
            }

            return uri;
           
        }
    }
}