using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using SPI_Cancellation_Service.Proxy.interfaces;
using SPI_Cancellation_Service.Utils;
using SPI_Cancellation_Service.Utils.mapper;
using SPI_Cancellation_Service.Utils.util;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Proxy.cancellation;
using SPI_Cancellation_Service.Domain.models.redeban.response;
using SPI_Cancellation_Service.Domain.models.openSearchModel;
using SPI_Cancellation_Service.Domain.models;
using SPI_Cancellation_Service.Domain.models.redeban;
using System.Diagnostics.CodeAnalysis;
using Azure;

namespace SPI_Cancellation_Service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class CancellationController : ControllerBase
    {
        private readonly IRedDeleteAccountService _deleteService = new RedDeleteAccountServiceImpl();
        private readonly ValidateService _validationService = new ValidateService();
        private readonly HeaderSerfiMapper _headersSerfiMapper = new HeaderSerfiMapper();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly ResponseSerfiMapper _rsSerfiMapper = new ResponseSerfiMapper();
        private readonly UriUtil _uriUtil = new UriUtil();

        public CancellationController()
        {
           
        }

        [HttpPut()]

        public async Task<IActionResult> DeleteKey([FromHeader(Name = HeadersSerfiEnum.IP_ORIGIN)] string ipOrigin,
                                                   [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                   [FromBody] ReqBPutKey body)
        {


            DeleteKeyRq deleteKeyRq = new DeleteKeyRq();
            deleteKeyRq.deleteHeaders = _headersSerfiMapper.mapHeaders(ipOrigin, uuidHeader, timestampsHeader, systemIdHeader);
            _validationService.validateHeaders(deleteKeyRq.deleteHeaders);
            Console.WriteLine("Termino el proceso de validacion de headers");
            string headers = UtilCommons.Object2String(deleteKeyRq.deleteHeaders);
            Console.WriteLine("Headers: " + headers);

            deleteKeyRq.reqBPutKey = body;
            string body1 = UtilCommons.Object2String(deleteKeyRq.reqBPutKey);
            Console.WriteLine("body: " + body1);

            MsgInformationResponse responseRedeban = null;

            try
            {


                Console.WriteLine("Iniciando proceso de eliminación de llave");
                
                //Validar el request
                _validationService.validateServiceDeleteKeyModel(deleteKeyRq.reqBPutKey);
                Console.WriteLine("Termino el proceso de validacion body");

                //// Llamar al servicio
                responseRedeban = await callRedebanAsync(deleteKeyRq);

                if (responseRedeban.messageInformation.msgCode == StatusCodeEnums.RED_PERSON_SUCCESS.getStatusCode() || responseRedeban.messageInformation.msgCode == StatusCodeEnums.RED_PERSON_CREATED.getStatusCode())
                {
                    Console.WriteLine("Se cancelo la llave exitosamente: " + responseRedeban.ToString());
                }
                else
                {
                    Console.WriteLine($"No se pudo cancelar la llave: " + responseRedeban.ToString());
                    throw new SerfiException(ResponseServiceEnums.SERVICE_RED_ERROR.getErrorCode(), ResponseServiceEnums.SERVICE_RED_ERROR.getMessage(), ResponseServiceEnums.SERVICE_RED_ERROR.getHttpCode());
                }


                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponse(deleteKeyRq, responseRedeban);

                Console.WriteLine("Finalizo el proceso");

                return Ok(responseService);
                
            }
            catch (SerfiException ex)
            {
                
                Console.WriteLine($"Error de serfinanzas: {ex.Message}");

                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadSerfiMessageResponse(deleteKeyRq, responseRedeban, ex);

                return BadRequest(responseService);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");

                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadMessageResponse(deleteKeyRq, responseRedeban, ex);
                return BadRequest();
            }
        }

        private async Task<MsgInformationResponse> callRedebanAsync(DeleteKeyRq rqDelete)
        {

            string apiUri = _uriUtil.BuildUri(rqDelete.reqBPutKey.key.keyType, rqDelete.reqBPutKey.key.keyId);
            Console.WriteLine($"URL completa: {apiUri}");
            

            // Obtener headers de la solicitud
            HeadersRq headersRed = _redRqMapper.MapHeadersFromRequest(rqDelete.deleteHeaders);
            DeleteRq deleteRqRed = _redRqMapper.MapBodyFromRequest(rqDelete.reqBPutKey, rqDelete.deleteHeaders);

            MsgInformationResponse response;
            response = await _deleteService.DeleteKeyAsync(apiUri, headersRed, deleteRqRed);
            Console.WriteLine($"Respuesta de redeban{UtilCommons.Object2String(response)}");

            return response;
        }
    }
}