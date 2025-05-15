using SPI_Cancellation_Service.Domain.models;
using SPI_Cancellation_Service.Infrastructure.repositories;

namespace SPI_Cancellation_Service.ApplicationCore.interfaces
{
    public interface IAuroraService
    {
        Task<KeyEntity> inquiryKey(AuroraDbContext _db,string keyType, string keyValue);
        Task<bool> cancelKey(AuroraDbContext _db,KeyEntity keyDb);
    }
}
