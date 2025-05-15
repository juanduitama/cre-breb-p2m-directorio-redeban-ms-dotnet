using System;
using System.Collections.Generic;
using SPI_Cancellation_Service.Domain.constants;

namespace SPI_Cancellation_Service.Utils.util
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
        public string BuildUri(string keyType, string keyValue)
        {
            string newUri = getValuePathParameters(ConstantsEnums.DELETE_URI.getValue(), PathParametersEnum.KEY_TYPE, keyType); 
            newUri = getValuePathParameters(newUri, PathParametersEnum.KEY_VALUE, keyValue);

            return ConstantsEnums.BASE_URI.getValue() + newUri;                
            
        }


        private string getValuePathParameters(string uri, PathParametersEnum pathParameter, string valueParameter)
        {
            if (uri.Contains(pathParameter.getValuePathParameters()))
            {
                return uri.Replace(pathParameter.getValuePathParameters(), valueParameter);
            }

            return uri;
           
        }
    }
}