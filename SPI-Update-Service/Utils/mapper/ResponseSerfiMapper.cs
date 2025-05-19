using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban.response;
using Amazon.Runtime.Internal;

namespace SPI_Update_Service.Utils.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi mapMessageResponseAccount(UpdateAccountRq updateKey, MessageInformation messageInformation)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = DateTime.Now.ToString(ValidationEnums.DATE_FORMAT).Replace("Z", "");
            meta.systemId = "";
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.UPDATE_RESPONSE_CODE_SUCCESS.getValue();
            msgInformationResponseSerfi.statusDesc = ResponseEnun.UPDATE_RESPONSE_DESC_SUCCESS_KEY.getValue();

            AditionalInfo aditionalInfoItem = new AditionalInfo();
            aditionalInfoItem.codigo = messageInformation.msgCode;
            aditionalInfoItem.detalle = messageInformation.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapMessageResponseKey(UpdateKeyRq updateKey, MessageInformation messageInformation)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = updateKey.updateHeaders.timeStamps;
            meta.systemId = updateKey.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.UPDATE_RESPONSE_CODE_SUCCESS.getValue();
            msgInformationResponseSerfi.statusDesc = ResponseEnun.UPDATE_RESPONSE_DESC_SUCCESS_KEY.getValue();

            AditionalInfo aditionalInfoItem = new AditionalInfo();
            aditionalInfoItem.codigo = messageInformation.msgCode;
            aditionalInfoItem.detalle = messageInformation.msgDescription;


            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }
    }
}
