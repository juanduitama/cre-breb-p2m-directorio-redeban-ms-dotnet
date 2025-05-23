using SPI_Update_Enterprise_Service.Domain.models.redeban.response;
using SPI_Update_Enterprise_Service.Domain.models.redeban;
using SPI_Update_Enterprise_Service.ApplicationCore.interfaces;

namespace SPI_Update_Enterprise_Service.Proxy.interfaces
{
    public interface IRedUpdateEnterpriseService
    {

        /// <summary>
        /// Método para eliminar una llave
        /// </summary>
        Task<MsgInformationResponse> UpdateEnterpriseAsync(string url, HeadersRq headers, UpdateRqRed deleteRq, IS3Service s3Service);
    }
}
