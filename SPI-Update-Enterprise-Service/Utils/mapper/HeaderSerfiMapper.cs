
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Domain.models.updateEnterprise;

namespace SPI_Update_Enterprise_Service.Utils.mapper
{
    public class HeaderSerfiMapper
    {

        public UpdateHeadersEnterprise mapHeaders(string ipOrigin, string uuId, string timeStamp, string systemId){
            UpdateHeadersEnterprise headers = new UpdateHeadersEnterprise();

            headers.ipOrigin = ipOrigin;
            headers.uuId = uuId;
            headers.timeStamps = DateTime.Now.ToString(ValidationEnums.DATE_FORMAT).Replace("Z","");
            headers.systemId = systemId;

            return headers;
        }

    }
}

