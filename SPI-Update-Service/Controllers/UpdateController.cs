using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using domain.models;
using domain.constants;
using domain.models.enrollment;
using domain.models.redeban;
using SPI_Update_Service.domain.models.redeban;
using domain.models.redeban.response;
using System.ComponentModel.DataAnnotations;
using SPI_Update_Service.Proxy.interfaces;
using SPI_Update_Service.Utils.util;
using SPI_Update_Service.Utils.mapper;
using SPI_Update_Service.Utils;
using Domain.constants;
using SPI_Update_Service.Proxy.update;
using SPI_Update_Service.Infrastructure.repositories;
using SPI_Update_Service.ApplicationCore.services;

namespace SPI_Update_Service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IRedUpdateService _updateService = new RedUpdateServiceImpl();
        private readonly UriUtil _uriUtil;
        private readonly ValidateService validateService = new ValidateService();
        private readonly HeaderSerfiMapper _headersMapper = new HeaderSerfiMapper();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly ResponseSerfiMapper _rsSerfiMapper;
        private readonly S3Repository _s3Repository;
        private readonly IS3Service _s3Service;

        public UpdateController()
        {
            _uriUtil = new UriUtil();
            _rsSerfiMapper = new ResponseSerfiMapper();
            _s3Repository = new S3Repository();
            _s3Service = new S3Service(_s3Repository);
        }

        [HttpPatch("account")]
        public async Task<IActionResult> UpdateAccount([Required][FromHeader(Name = HeadersSerfiEnum.IPORIGIN)] string ipOrigin,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                       [FromBody] ReqBPatchAccount body)
        {

            //validate request
            //Validar que la llave exista
            //El estado debe de la llave consultada debe estar activa
            //el num documento del request debe ser el mismo que el id de os
            // Setear campos que se quieran cambiar
            // Consumo redeban
            // Validar respuesta de redeban
            // Guarda nuevo resgistro en opSearch
            // elimina resgitro anterior en opSearch


            UpdateAccountRq request = new UpdateAccountRq();
            request.updateHeaders = _headersMapper.mapHeaders(ipOrigin, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = UtilCommons.Object2String(request.updateHeaders);
            Console.WriteLine("headers: " + headers);

            request.reqBPatchAccount = body;
            string body1 = UtilCommons.Object2String(request.reqBPatchAccount);
            Console.WriteLine("body: " + body1);
            MsgInformationResponse responseRedeban = null;

            try
            {
                Console.WriteLine("Iniciando proceso de actualización de cuenta");

                validateService.ValidateHeaders(request.updateHeaders);
                validateService.ValidateServiceUpdateAccountModel(request);

                //Buscamos llave
                //OSDefinitive opSearchOldEntity = await _openSearchService.SearchKey(request.reqBPatchAccount.key.keyType, request.reqBPatchAccount.key.keyId);

                //string opSearchOldEntityPrint = await UtilCommons.Object2String(opSearchOldEntity);
                //Console.WriteLine("OS entity: " + opSearchOldEntityPrint);

                //validateService.validateOSEntityAccount(request, opSearchOldEntity);

                string apiUri = _uriUtil.BuildUriAccount(request.reqBPatchAccount.key.keyId, request.reqBPatchAccount.key.keyType);

                //string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/AccountUpdate";

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);

                UpdateAcctRq updateBody = _redRqMapper.MapBodyAccountFromRequest(request.reqBPatchAccount, request.updateHeaders);

                // Llamar al servicio
                responseRedeban = await _updateService.UpdateAccountAsync(apiUri, headersRq, updateBody, _s3Service);

                Console.WriteLine("Respuesta de redeban: " + UtilCommons.Object2String(responseRedeban));
                if (responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE.getValue() || responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE.getValue())
                {
                    Console.WriteLine("Se modificó el producto exitosamente. ");
                }
                else
                {
                    Console.WriteLine($"No se pudo modificar el producto. ");
                    throw new SerfiException(ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getMessage(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getHttpCode());
                }

                //Console.WriteLine("Iniciando proceso de guardado en open search.");
                // Falta mapeo
                //OSDefinitive entityToSave = _rqMapperOs.mapUpdateAccountOSDefinitiveFromRequest(request, opSearchOldEntity);

                //await _openSearchService.SaveKey(entityToSave);

                //await _openSearchService.DeleteKey(opSearchOldEntity.key.keyType, opSearchOldEntity.key.keyId);

                //Console.WriteLine("Se modificó en open search correctamente.");


                //MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseAccount(entityToSave, request, response);
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseAccount(request, responseRedeban.messageInformation);


                Console.WriteLine("Finalizo el proceso");

                return Ok(responseService);
            }
            catch (SerfiException ex)
            {
                Console.WriteLine($"Error de serfinanzas: {ex.Message}");
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadResponseSerfiAccount(request, responseRedeban, ex);
                return BadRequest(responseService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la inscripción: {ex.Message}");
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadResponseGenericAccount(request, responseRedeban, ex);
                return BadRequest(responseService);
            }
        }

        [HttpPatch("key")]
        public async Task<IActionResult> UpdateKey([FromHeader(Name = HeadersSerfiEnum.IPORIGIN)] string ipOrigin,
                                                   [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                   [FromBody] ReqBPatchKey body)
        {

            UpdateKeyRq request = new UpdateKeyRq();
            request.updateHeaders = _headersMapper.mapHeaders(ipOrigin, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = UtilCommons.Object2String(request.updateHeaders);
            Console.WriteLine("headers: " + headers);

            request.reqBPatchKey = body;
            string body1 = UtilCommons.Object2String(request.reqBPatchKey);
            Console.WriteLine("body: " + body1);

            MsgInformationResponse responseRedeban = null; 


            try
            {
                Console.WriteLine("Iniciando proceso de actualización de llave");
                validateService.ValidateHeaders(request.updateHeaders);
                validateService.ValidateServiceUpdateKeyModel(request);

                string apiUri = _uriUtil.BuildUriKey(request.reqBPatchKey.custInfo.custIdent.custIdentId);

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);
                UpdateKeyPersonRq updateBody = _redRqMapper.MapBodyKeyFromRequest(request);

                // Llamar al servicio
                responseRedeban = await _updateService.UpdateKeyAsync(apiUri, headersRq, updateBody, _s3Service);

                if(responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE.getValue() || responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE.getValue())
                {
                    Console.WriteLine("Se modificó la llave exitosamente: " + UtilCommons.Object2String(responseRedeban));
                }
                else
                {
                    Console.WriteLine($"No se pudo modificar la llave. ");
                    throw new SerfiException(ResponseServiceEnum.SERVICE_KEY_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_KEY_ERROR.getMessage(), ResponseServiceEnum.SERVICE_KEY_ERROR.getHttpCode());
                }

                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseKey(request, responseRedeban.messageInformation);

                Console.WriteLine("Finalizo el proceso de modificación");

                return Ok(responseService);
            }
            catch (SerfiException ex)
            {
                Console.WriteLine($"Error de serfinanzas: {ex.Message}");
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadMessageSerfiResponseKey(request, responseRedeban, ex);
                return BadRequest(responseService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la inscripción: {ex.Message}");
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapBadMessageGenericResponseKey(request, responseRedeban, ex);
                return BadRequest(responseService);
            }
        }
    }

}
