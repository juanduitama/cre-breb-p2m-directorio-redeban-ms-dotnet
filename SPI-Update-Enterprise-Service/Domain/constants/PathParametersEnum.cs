namespace SPI_Update_Enterprise_Service.Domain.constants
{
    public  enum PathParametersEnums
    {
        MERCHANT_ID

    }

    public static class PathParametersEnumsExtensions
    {
        public static string getValuePathParameters(this PathParametersEnums pathParameters)
        {
            return pathParameters switch
            {
                PathParametersEnums.MERCHANT_ID => "{MerchantID}",
                _ => throw new ArgumentOutOfRangeException(nameof(pathParameters))
            };
        }
    }
}
