using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Cancellation_Service.Domain.models;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.redeban.response;

namespace SPI_Cancellation_Service.Utils.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi mapMessageResponse(DeleteKeyRq request, MsgInformationResponse responseRedeban){

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.deleteHeaders.uuId;
            meta.timeStamp = request.deleteHeaders.timeStamps;
            meta.systemId = request.deleteHeaders.systemId;
            response.meta = meta;

            response.statusCodigo = ResponseEnums.ENRROLLMENT_RESPONSE_SUCCESS.getResponseCode();
            response.statusDesc = ResponseEnums.ENRROLLMENT_RESPONSE_SUCCESS.getResponseMessage();

            AditionalInfo aditionalInfo = new AditionalInfo();
            aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
            aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

            aditionalInfoList.Add(aditionalInfo);

            response.aditionalInfo = aditionalInfoList;

            Data data = new Data();
            data.merchantId = "";
            response.data = data;

            return response;
        }
    }

}
