using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models.delete
{
    public class DeleteKeyRq
    {
        public DeleteHeaders? deleteHeaders { get; set; }

        public ReqBPutKey? reqBPutKey { get; set; }
    }
}
