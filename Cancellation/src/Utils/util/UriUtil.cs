using System;
using System.Collections.Generic;
using SPI_Cancellation_Service.Domain.constants;

namespace SPI_Cancellation_Service.Utils.util
{
    public class UriUtil
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUri;

        public UriUtil(IConfiguration configuration = null)
        {
            _configuration = configuration;

            // Si hay configuración disponible, usar la URL base de las configuraciones
            if (_configuration != null)
            {
                _baseUri = _configuration["ApiSettings:BaseUrl"] ?? ConstantsEnum.BASE_URI;
            }
            else
            {
                // De lo contrario, usar la URL base definida en las constantes
                _baseUri = ConstantsEnum.BASE_URI;
            }
        }

        /// <summary>
        /// Construye una URI para consultas basada en el tipo de operación y parámetros de ruta
        /// </summary>
        /// <param name="methodDescription">Tipo de operación según las constantes definidas</param>
        /// <param name="routeValues">Diccionario con los valores de ruta</param>
        /// <returns>URI completa para la operación</returns>
        public string BuildUri(string keyType, string keyValue)
        {
            string newUri = getValuePathParameters(ConstantsEnum.DELETE_URI, PathParametersEnum.KEY_TYPE, keyType); 
            newUri = getValuePathParameters(newUri, PathParametersEnum.KEY_VALUE, keyValue);

            return _baseUri + newUri;                
            
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