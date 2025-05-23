using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models;
using SPI_Update_Enterprise_Service.Domain.models.updateEnterprise;
using SPI_Update_Enterprise_Service.Domain.models.redeban.response;
using SPI_Update_Enterprise_Service.Utils.util;


namespace SPI_Update_Enterprise_Service.Utils.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi mapMessageResponse(UpdateEnterpriseRq request, MsgInformationResponse responseRedeban){

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.updateHeadersEnterprise.uuId;
            meta.timeStamp = request.updateHeadersEnterprise.timeStamps;
            meta.systemId = request.updateHeadersEnterprise.systemId;
            response.meta = meta;

            response.statusCodigo = ResponseEnums.UPDATE_RESPONSE_SUCCESS.getResponseCode();
            response.statusDesc = ResponseEnums.UPDATE_RESPONSE_SUCCESS.getResponseMessage();

            AditionalInfo aditionalInfo = new AditionalInfo();
            aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
            aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

            aditionalInfoList.Add(aditionalInfo);

            response.aditionalInfo = aditionalInfoList;

            Data data = new Data();
            if (!string.IsNullOrWhiteSpace(request.reqBPatchEnterprise.merchantId))
            {
                data.merchantId = request.reqBPatchEnterprise.merchantId;
            }

            response.data = data;

            return response;
        }

        public MsgInformationResponseSerfi mapBadSerfiMessageResponse(UpdateEnterpriseRq request, MsgInformationResponse responseRedeban, SerfiException serfExc)
        {

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.updateHeadersEnterprise.uuId;
            meta.timeStamp = request.updateHeadersEnterprise.timeStamps;
            meta.systemId = request.updateHeadersEnterprise.systemId;
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
            
            if(!string.IsNullOrWhiteSpace(request.reqBPatchEnterprise.merchantId))
            {
                data.merchantId = request.reqBPatchEnterprise.merchantId;
            }
            
            response.data = data;

            return response;
        }

        public MsgInformationResponseSerfi mapBadMessageResponse(UpdateEnterpriseRq request, MsgInformationResponse responseRedeban, Exception ex)
        {

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.updateHeadersEnterprise.uuId;
            meta.timeStamp = request.updateHeadersEnterprise.timeStamps;
            meta.systemId = request.updateHeadersEnterprise.systemId;
            response.meta = meta;

            response.statusCodigo = ResponseServiceEnums.SERVICE_INTERNAL_ERROR.getErrorCode();
            response.statusDesc = ex.Message;

            AditionalInfo aditionalInfo = new AditionalInfo();


            aditionalInfo.codigo = responseRedeban.messageInformation.msgCode;
            aditionalInfo.detalle = responseRedeban.messageInformation.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

            aditionalInfoList.Add(aditionalInfo);

            response.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            if (!string.IsNullOrWhiteSpace(request.reqBPatchEnterprise.merchantId))
            {
                data.merchantId = request.reqBPatchEnterprise.merchantId;
            }

            response.data = data;

            return response;
        }
    }

}
