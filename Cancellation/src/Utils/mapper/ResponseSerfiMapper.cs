using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Cancellation_Service.Domain.models;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.redeban.response;
using SPI_Cancellation_Service.Utils.util;

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

            response.statusCodigo = ResponseEnums.CANCELLATION_RESPONSE_SUCCESS.getResponseCode();
            response.statusDesc = ResponseEnums.CANCELLATION_RESPONSE_SUCCESS.getResponseMessage();

            AditionalInfo aditionalInfo = new AditionalInfo();
            aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
            aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

            aditionalInfoList.Add(aditionalInfo);

            response.aditionalInfo = aditionalInfoList;

            Data data = new Data();
            data.merchantId = "";
            response.data = string.IsNullOrEmpty(data.merchantId) ? null : data;

            return response;
        }

        public MsgInformationResponseSerfi mapBadSerfiMessageResponse(DeleteKeyRq request, MsgInformationResponse responseRedeban, SerfiException serfExc)
        {

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.deleteHeaders.uuId;
            meta.timeStamp = request.deleteHeaders.timeStamps;
            meta.systemId = request.deleteHeaders.systemId;
            response.meta = meta;

            response.statusCodigo = serfExc.errorCode;
            response.statusDesc = serfExc.message;
            
            AditionalInfo aditionalInfo = new AditionalInfo();

            if(responseRedeban != null)
            {
                aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
                aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

                List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

                aditionalInfoList.Add(aditionalInfo);

                response.aditionalInfo = aditionalInfoList;
            }
            

            Data data = new Data();
            
            data.merchantId = "";
            response.data = string.IsNullOrEmpty(data.merchantId) ? null : data;

            return response;
        }

        public MsgInformationResponseSerfi mapBadMessageResponse(DeleteKeyRq request, MsgInformationResponse responseRedeban, Exception ex)
        {

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.deleteHeaders.uuId;
            meta.timeStamp = request.deleteHeaders.timeStamps;
            meta.systemId = request.deleteHeaders.systemId;
            response.meta = meta;

            response.statusCodigo = ResponseServiceEnums.SERVICE_INTERNAL_ERROR.getErrorCode();
            response.statusDesc = ex.Message;

            AditionalInfo aditionalInfo = new AditionalInfo();

            if(responseRedeban != null)
            {
                aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
                aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

                List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

                aditionalInfoList.Add(aditionalInfo);

                response.aditionalInfo = aditionalInfoList;
            }

            Data data = new Data();
            data.merchantId = "";
            response.data = string.IsNullOrEmpty(data.merchantId) ? null : data;

            return response;
        }
    }

}
