using Microsoft.AspNetCore.Mvc;
using SPI_Update_Enterprise_Service.ApplicationCore.interfaces;
using SPI_Update_Enterprise_Service.Domain.models.redeban.response;
using SPI_Update_Enterprise_Service.Domain.models.redeban;
using SPI_Update_Enterprise_Service.Utils.mapper;
using SPI_Update_Enterprise_Service.Utils.util;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Domain.models.updateEnterprise;
using SPI_Update_Enterprise_Service.Utils;
using SPI_Update_Enterprise_Service.Proxy.interfaces;
using SPI_Update_Enterprise_Service.Proxy.update;
using SPI_Update_Enterprise_Service.Infrastructure.repositories;
using SPI_Update_Enterprise_Service.ApplicationCore.services;
using SPI_Cancellation_Service.Domain.models;

namespace SPI_Update_Enterprise_Service.Controllers
{
    [ApiController]
    [Route("enterprise/Commerce/[controller]")]
    public class UpdateEnterpriseController : ControllerBase
    {
        private readonly HeaderSerfiMapper _headersSerfiMapper;
        private readonly ValidateService _validateService;
        private readonly UriUtil _uriUtil;
        private readonly RedRqMapper _redRqMapper;
        private readonly ResponseSerfiMapper _rsSerfiMapper;
        private readonly IRedUpdateEnterpriseService _updateEntService;
        private readonly S3Repository _s3Repository;
        private readonly IS3Service _s3Service;

        public UpdateEnterpriseController()
        {
            _headersSerfiMapper = new HeaderSerfiMapper();
            _validateService = new ValidateService();
            _uriUtil = new UriUtil();
            _redRqMapper = new RedRqMapper();
            _rsSerfiMapper = new ResponseSerfiMapper();
            _updateEntService = new RedUpdateEnterpriseServiceImpl();
            _s3Repository = new S3Repository();
            _s3Service = new S3ServiceImpl(_s3Repository);
        }
        [HttpPatch()]
        public async Task<IActionResult> UpdateEnterprise([FromHeader(Name = HeadersSerfiEnum.IP_ORIGIN)] string ipOrigin,
                                                   [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                   [FromBody] ReqBPatchEnterprise body)
        {

            UpdateEnterpriseRq updateEnterpriseRq = new UpdateEnterpriseRq();
            updateEnterpriseRq.updateHeadersEnterprise = _headersSerfiMapper.mapHeaders(ipOrigin, uuidHeader, timestampsHeader, systemIdHeader);
            _validateService.validateHeaders(updateEnterpriseRq.updateHeadersEnterprise);
            Console.WriteLine("Termino el proceso de validacion de headers");
            string headers = UtilCommons.Object2String(updateEnterpriseRq.updateHeadersEnterprise);
            Console.WriteLine($" [INFO] Headers: {headers}");

            updateEnterpriseRq.reqBPatchEnterprise = body;
            string body1 = UtilCommons.Object2String(updateEnterpriseRq.reqBPatchEnterprise);
            Console.WriteLine("body: " + body1);

            MsgInformationResponse responseRedeban = null;

            try
            {
                Console.WriteLine("Inicio microservicio actualización empresas");

                

                Console.WriteLine("Iniciando proceso de actualización de empresas");

                //Validar el request
                _validateService.validateServiceBody(updateEnterpriseRq.reqBPatchEnterprise);
                Console.WriteLine("Termino el proceso de validacion body");

                //// Llamar al servicio
                responseRedeban = await callRedebanAsync(updateEnterpriseRq);

                if (responseRedeban.messageInformation.msgCode == StatusCodeEnums.RED_PERSON_SUCCESS.getStatusCode() || responseRedeban.messageInformation.msgCode == StatusCodeEnums.RED_PERSON_CREATED.getStatusCode())
                {
                    Console.WriteLine("Se cancelo la llave exitosamente: " + responseRedeban.ToString());
                }
                else
                {
                    Console.WriteLine($"No se pudo cancelar la llave: " + responseRedeban.ToString());
                    throw new SerfiException(ResponseServiceEnums.SERVICE_RED_ERROR.getErrorCode(), ResponseServiceEnums.SERVICE_RED_ERROR.getMessage(), ResponseServiceEnums.SERVICE_RED_ERROR.getHttpCode());
                }


                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponse(updateEnterpriseRq, responseRedeban);

                Console.WriteLine("Finalizo el proceso");

                return StatusCode(ResponseEnums.UPDATE_RESPONSE_SUCCESS.getHttpCode(),responseService);

            }
            catch (SerfiException ex)
            {

                Console.WriteLine($"Error de serfinanzas: {ex.Message}");

                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadSerfiMessageResponse(updateEnterpriseRq, responseRedeban, ex);

                return StatusCode(ex.httpCode,responseService);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");

                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadMessageResponse(updateEnterpriseRq, responseRedeban, ex);
                return StatusCode(ResponseEnums.UPDATE_RESPONSE_ERROR.getHttpCode(), responseService);
            }
        }

        private async Task<MsgInformationResponse> callRedebanAsync(UpdateEnterpriseRq updateEnterpriseRq)
        {

            string apiUri = _uriUtil.BuildUri(updateEnterpriseRq.reqBPatchEnterprise.merchantId);
            Console.WriteLine($"URL completa: {apiUri}");


            // Obtener headers de la solicitud
            HeadersRq headersRed = _redRqMapper.MapHeadersFromRequest(updateEnterpriseRq.updateHeadersEnterprise);
            UpdateRqRed updateRqRed = _redRqMapper.MapBodyFromRequest(updateEnterpriseRq.reqBPatchEnterprise, updateEnterpriseRq.updateHeadersEnterprise);

            MsgInformationResponse response;
            response = await _updateEntService.UpdateEnterpriseAsync(apiUri, headersRed, updateRqRed, _s3Service);
            Console.WriteLine($"Respuesta de redeban{UtilCommons.Object2String(response)}");

            return response;
        }
    }
}
