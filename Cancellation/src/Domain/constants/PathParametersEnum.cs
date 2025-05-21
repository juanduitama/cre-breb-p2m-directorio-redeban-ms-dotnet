namespace SPI_Cancellation_Service.Domain.constants
{
    public  enum PathParametersEnums
    {
        KEY_TYPE,
        KEY_VALUE

    }

    public static class PathParametersEnumsExtensions
    {
        public static string getValuePathParameters(this PathParametersEnums pathParameters)
        {
            return pathParameters switch
            {
                PathParametersEnums.KEY_TYPE => "{keyType}",
                PathParametersEnums.KEY_VALUE => "{keyValue}",
                _ => throw new ArgumentOutOfRangeException(nameof(pathParameters))
            };
        }
    }
}
