using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPI_Cancellation_Service.Domain.models.redeban;
using SPI_Cancellation_Service.Domain.models.redeban.response;


namespace SPI_Cancellation_Service.Proxy.interfaces
{
    public interface IRedDeleteAccountService
    {
        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<MsgInformationResponse> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq deleteRq);
    }
}
