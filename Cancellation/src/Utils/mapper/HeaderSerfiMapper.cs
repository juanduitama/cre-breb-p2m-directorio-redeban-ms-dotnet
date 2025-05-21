
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.constants;

namespace SPI_Cancellation_Service.Utils.mapper
{
    public class HeaderSerfiMapper
    {

        public DeleteHeaders mapHeaders(string ipOrigin, string uuId, string timeStamp, string systemId){
            DeleteHeaders headers = new DeleteHeaders();

            headers.ipOrigin = ipOrigin;
            headers.uuId = uuId;
            headers.timeStamps = DateTime.Now.ToString(ValidationEnums.DATE_FORMAT).Replace("Z","");
            headers.systemId = systemId;

            return headers;
        }

    }
}

