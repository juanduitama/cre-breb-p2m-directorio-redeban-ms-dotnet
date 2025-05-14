using System.ComponentModel.DataAnnotations;

namespace SPI_Cancellation_Service.Domain.models.openSearchModel
{
    public class OSDefinitive
    {
        [Required]
        public string? rqUID { get; set; }
        
        public AcctInfo acctInfo { get; set; }
        
        public CustInfoOS custInfoOS { get; set; }
        
        public Key key { get; set; }
        
        public VaultInsc vaultInsc { get; set; }

        [Required]
        public DateTime effDtCreate { get; set; }
        
        public DateTime? effDtModify { get; set; }
    }
}
