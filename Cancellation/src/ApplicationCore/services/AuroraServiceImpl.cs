using SPI_Cancellation_Service.ApplicationCore.interfaces;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models;
using SPI_Cancellation_Service.Infrastructure.repositories;
using SPI_Cancellation_Service.Utils.util;

namespace SPI_Cancellation_Service.ApplicationCore.services
{
    public class AuroraServiceImpl : IAuroraService
    {
        public async Task<KeyEntity> inquiryKey(AuroraDbContext _db, string keyType, string keyValue)
        {
            try
            {
                // Assuming key is the DbSet for KeyEntity
                var keyEntity = await _db.key.FindAsync(keyType, keyValue);
                if (keyEntity == null)
                {
                    throw new SerfiException(ResponseServiceEnum.AURORA_ERROR.getErrorCode(), ResponseServiceEnum.AURORA_ERROR.getMessage(), ResponseServiceEnum.AURORA_ERROR.getHttpCode());
                }

                Console.WriteLine($"[INFO] Llave encontrada: {UtilCommons.Object2String(keyEntity)}");
                return keyEntity;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"[ERROR]: Llave no fue encontrada en el directorio de aurora {ex.Message}");
                throw new SerfiException(ResponseServiceEnum.AURORA_ERROR.getErrorCode(), ResponseServiceEnum.AURORA_ERROR.getMessage(), ResponseServiceEnum.AURORA_ERROR.getHttpCode());
            }

        }
        public async Task<bool> cancelKey(AuroraDbContext _db, KeyEntity keyDb)
        {
            // Implement the logic to cancel the key here
            try
            {
                // Assuming keyDb is the entity to be removed
                _db.key.Remove(keyDb); // Assuming key is the DbSet for KeyEntity
                _db.SaveChanges();
                Console.WriteLine("Llave cancelada con exito.");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new SerfiException(ResponseServiceEnum.AURORA_ERROR.getErrorCode(), ResponseServiceEnum.AURORA_ERROR.getMessage(), ResponseServiceEnum.AURORA_ERROR.getHttpCode());
            }
        }        
    }
}
