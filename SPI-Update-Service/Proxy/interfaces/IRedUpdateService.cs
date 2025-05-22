using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.models.redeban;
using domain.models.redeban.response;
using SPI_Update_Service.ApplicationCore.services;
using SPI_Update_Service.domain.models.redeban;

namespace SPI_Update_Service.Proxy.interfaces
{
    public interface IRedUpdateService
    {
        Task<MsgInformationResponse> UpdateAsync(string url, HeadersRq headers, UpdateKeyPersonRq keyRequest, UpdateAcctRq accountRequest, IS3Service s3Service);
    }
}
