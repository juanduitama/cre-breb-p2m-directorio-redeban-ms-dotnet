
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models.enrollment;

namespace SPI_Update_Service.Utils.mapper
{
    public class HeaderSerfiMapper
    {

        public UpdateHeaders mapHeaders(string ipOrigin, string uuId, string timeStamp, string systemId)
        {
            UpdateHeaders headers = new UpdateHeaders();

            headers.ipOrigin = ipOrigin;
            headers.uuId = uuId;
            headers.timeStamp = timeStamp;
            headers.systemId = systemId;

            return headers;
        }

    }
}

