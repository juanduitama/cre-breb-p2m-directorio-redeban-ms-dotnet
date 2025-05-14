using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
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

namespace SPI_Cancellation_Service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class DeleteController : ControllerBase
    {
        private readonly IRedDeleteAccountService _deleteService = new RedDeleteAccountServiceImpl();
        private readonly ValidateService _validationService = new ValidateService();
        private readonly HeaderSerfiMapper _headersSerfiMapper = new HeaderSerfiMapper();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly ResponseSerfiMapper _rsSerfiMapper = new ResponseSerfiMapper();
        private readonly ILogger<DeleteController> _logger;
        private readonly UriUtil _uriUtil;

        public DeleteController(
            IRedDeleteAccountService deleteService,
            ILogger<DeleteController> logger)
        {
            _deleteService = deleteService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPut("cancellation")]
        public async Task<IActionResult> DeleteKey([Required][FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                   [Required][FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                   [Required][FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                   [Required][FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                   [Required][FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                   [FromBody] ReqBPutKey body)
        {
            

            DeleteKeyRq deleteKeyRq = new DeleteKeyRq();
            deleteKeyRq.deleteHeaders = _headersSerfiMapper.mapHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = await UtilCommons.Object2String(deleteKeyRq.deleteHeaders);
            Console.WriteLine("Headers: " + headers);

            deleteKeyRq.reqBPutKey = body;
            string body1 = await UtilCommons.Object2String(deleteKeyRq.reqBPutKey);
            Console.WriteLine("body: " + body1);

            //Validar Request         
            // Buscar en OS la llave que exista y este activa
            // Cancelar en redeban 
            // cancelar en open

            try
            {
                
                _logger.LogInformation("Iniciando proceso de eliminación de llave");
                MsgInformationResponse responseRedeban;
                //Validar el request
                _validationService.validateServiceDeleteKeyModel(deleteKeyRq.reqBPutKey);
                _logger.LogInformation("Termino el proceso de validacion");
                
                //Consulta la llave que se va a cancelar
                //OSDefinitive opSearchEntity = await _openSearchService.SearchKey(deleteKeyRq.reqBPutKey.key.keyType, deleteKeyRq.reqBPutKey.key.keyId);
                //string opSearchEntityPrint = await UtilCommons.Object2String(opSearchEntity);
                //_logger.LogInformation("OS entity: " + opSearchEntityPrint);

                //_validationService.validateOSEntity(deleteKeyRq.reqBPutKey, opSearchEntity);
                

                string apiUri = _uriUtil.BuildUri(deleteKeyRq.reqBPutKey.key.keyType,deleteKeyRq.reqBPutKey.key.keyId);
                //string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/Cancellation";
                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headersRed = _redRqMapper.MapHeadersFromRequest(deleteKeyRq.deleteHeaders);

                DeleteRq deleteRqRed = _redRqMapper.MapBodyFromRequest(deleteKeyRq.reqBPutKey, new OSDefinitive());

                //// Llamar al servicio
                responseRedeban = await _deleteService.DeleteKeyAsync(apiUri, headersRed, deleteRqRed);

                if(responseRedeban.messageInformation != null)
                {
                    if (responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
                    {
                        _logger.LogInformation("Se cancelo la llave exitosamente: " + responseRedeban.ToString());
                    }
                    else
                    {
                        _logger.LogError($"No se pudo cancelar la llave: " + responseRedeban.ToString());
                        throw new SerfiException(ResponseServiceEnum.SERVICE_KEY_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_KEY_ERROR.getMessage(), ResponseServiceEnum.SERVICE_KEY_ERROR.getHttpCode());
                    }

                    //await _openSearchService.CancelledKey(opSearchEntity.key.keyType, opSearchEntity.key.keyId, opSearchEntity);

                    //_logger.LogInformation("Se modificó en open search correctamente.");

                    MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponse(deleteKeyRq, responseRedeban);


                    _logger.LogInformation("Finalizo el proceso");

                    return Ok(responseService);
                }
                else
                {
                    throw new SerfiException(ResponseServiceEnum.SERVICE_INTERNAL_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_INTERNAL_ERROR.getMessage(), ResponseServiceEnum.SERVICE_INTERNAL_ERROR.getHttpCode());
                }                
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error al procesar JSON: {ex.Message}");

                return BadRequest(new
                {
                    error = "Formato JSON inválido",
                    message = ex.Message
                });
            }
            catch (SerfiException ex)
            {
                _logger.LogError($"Error de serfinanzas: {ex.Message}");

                return BadRequest(new
                {
                    code = ex.errorCode,
                    error = ex.message
                });
            }
        }
    }
}