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
        public MsgInformationResponseSerfi mapMessageResponseAccount(UpdateAccountRq updateAccount, MessageInformation messageInformation)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateAccount.updateHeaders.uuId;
            meta.timeStamp = updateAccount.updateHeaders.timeStamp;
            meta.systemId = updateAccount.updateHeaders.systemId;
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
            meta.timeStamp = updateKey.updateHeaders.timeStamp;
            meta.systemId = updateKey.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.UPDATE_RESPONSE_CODE_SUCCESS.getValue();
            msgInformationResponseSerfi.statusDesc = ResponseEnun.UPDATE_RESPONSE_DESC_SUCCESS_KEY.getValue();


            AditionalInfo aditionalInfoItem = new AditionalInfo();

            if (messageInformation != null)
            {
                aditionalInfoItem.codigo = messageInformation.msgCode;
                aditionalInfoItem.detalle = messageInformation.msgDescription;
            }

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapBadResponseSerfiAccount(UpdateAccountRq updateAccount, MsgInformationResponse messageInformation, SerfiException ex)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateAccount.updateHeaders.uuId;
            meta.timeStamp = updateAccount.updateHeaders.timeStamp;
            meta.systemId = updateAccount.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ex.errorCode;
            msgInformationResponseSerfi.statusDesc = ex.message;


            AditionalInfo aditionalInfoItem = new AditionalInfo();

            if (messageInformation != null)
            {
                aditionalInfoItem.codigo = messageInformation.messageInformation.msgCode;
                aditionalInfoItem.detalle = messageInformation.messageInformation.msgDescription;
            }

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapBadResponseGenericAccount(UpdateAccountRq updateAccount, Exception ex)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateAccount.updateHeaders.uuId;
            meta.timeStamp = updateAccount.updateHeaders.timeStamp;
            meta.systemId = updateAccount.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.UPDATE_BAD_RESPONSE_CODE.getValue();
            msgInformationResponseSerfi.statusDesc = ResponseEnun.UPDATE_BAD_RESPONSE_MESSAGE_GENERIC.getValue();

            AditionalInfo aditionalInfoItem = new AditionalInfo();

            aditionalInfoItem.codigo = ResponseEnun.UPDATE_BAD_RESPONSE_CODE.getValue();
            aditionalInfoItem.detalle = ex.Message;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;

            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapBadMessageSerfiResponseKey(UpdateKeyRq updateKey, MsgInformationResponse messageInformation, SerfiException ex)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = updateKey.updateHeaders.timeStamp;
            meta.systemId = updateKey.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ex.errorCode;
            msgInformationResponseSerfi.statusDesc = ex.message;


            AditionalInfo aditionalInfoItem = new AditionalInfo();

            if (messageInformation != null)
            {
                aditionalInfoItem.codigo = messageInformation.messageInformation.msgCode;
                aditionalInfoItem.detalle = messageInformation.messageInformation.msgDescription;
            }

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapBadMessageGenericResponseKey(UpdateKeyRq updateKey, Exception ex)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = updateKey.updateHeaders.timeStamp;
            meta.systemId = updateKey.updateHeaders.systemId;
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.UPDATE_BAD_RESPONSE_CODE.getValue();
            msgInformationResponseSerfi.statusDesc = ResponseEnun.UPDATE_BAD_RESPONSE_MESSAGE_GENERIC.getValue();


            AditionalInfo aditionalInfoItem = new AditionalInfo();

            aditionalInfoItem.codigo = ResponseEnun.UPDATE_BAD_RESPONSE_CODE.getValue();
            aditionalInfoItem.detalle = ex.Message;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }
    }
}
