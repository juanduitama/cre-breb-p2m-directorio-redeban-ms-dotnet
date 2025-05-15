using Amazon.DynamoDBv2.DataModel;
using domain.constants;
using domain.models.redeban;
using SPI_Update_Service.Domain.models.dynamo;
using SPI_Update_Service.Proxy.interfaces;
using SPI_Update_Service.Utils.util;

namespace SPI_Update_Service.ApplicationCore.services
{
    public class DynamoService : IDynamoService
    {
        public async Task delete(DynamoDBContext dynamoContext, KeyEntity keyEntity)
        {
            try
            {
                await dynamoContext.DeleteAsync(keyEntity);
                Console.WriteLine("Se elimino con exito el registro: " + keyEntity.id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar operación de eliminación" + ex.ToString());
                throw new SerfiException(ResponseServiceEnum.DYNAMO_ERROR.getErrorCode(), ResponseServiceEnum.DYNAMO_ERROR.getMessage(), ResponseServiceEnum.DYNAMO_ERROR.getHttpCode());
            }
        }

        public async Task<KeyEntity> load(DynamoDBContext dynamoContext, string id, string sk)
        {
            try {
                KeyEntity key =await dynamoContext.LoadAsync<KeyEntity>(id, sk);

                if (key != null)
                {
                    Console.WriteLine("Se encontró el siguiente registro: " + await UtilCommons.Object2String(key));
                }
                else
                {
                    Console.WriteLine("No hay registros con esta llave: " + id);
                }
                return key;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar operación de búsqueda" + ex.ToString());
                throw new SerfiException(ResponseServiceEnum.DYNAMO_ERROR.getErrorCode(), ResponseServiceEnum.DYNAMO_ERROR.getMessage(), ResponseServiceEnum.DYNAMO_ERROR.getHttpCode());
            }   
        }

        public async Task save(DynamoDBContext dynamoContext, KeyEntity keyEntity)
        {
            try
            {
                await dynamoContext.SaveAsync(keyEntity);
                Console.WriteLine("Se guardo con exito el registro: " + keyEntity.id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar operación de guardado" + ex.ToString());
                throw new SerfiException(ResponseServiceEnum.DYNAMO_ERROR.getErrorCode(), ResponseServiceEnum.DYNAMO_ERROR.getMessage(), ResponseServiceEnum.DYNAMO_ERROR.getHttpCode());
            }
        }
    }
}
