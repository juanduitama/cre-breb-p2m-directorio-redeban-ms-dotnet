using SPI_Cancellation_Service.Domain.models.oAuth;

namespace SPI_Cancellation_Service.Proxy.interfaces
{
    public interface IOAuthService
    {
        Task<bool> validateToken(string token);

        Task<RsOAuth> getToken(string url, HttpClient _httpClient);
    }
}
