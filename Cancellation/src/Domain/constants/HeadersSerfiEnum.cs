namespace SPI_Cancellation_Service.Domain.constants
{
    public class HeadersSerfiEnum
    {

        /// <summary>
        /// El token de autorizacion para el consumo del servicio.
        /// </summary>
        public const string IP_ORIGIN = "ipOrigin";

        /// <summary>
        /// Indica el tipo de medio original del recurso.
        /// </summary>
        public const string UUID = "uuId";

        /// <summary>
        /// Indica la fecha y hora en que se invocó el servicio por la entidad.
        /// </summary>
        public const string TIMESTAMPS = "timeStamps";

        /// <summary>
        /// El origen de la dirección IP de un cliente.
        /// </summary>
        public const string SYSTEMID = "systemId";
    }
}
