namespace SPI_Cancellation_Service.Domain.constants
{
    public  enum PathParametersEnum
    {
        KEY_TYPE,
        KEY_VALUE

    }

    public static class PathParametersEnumExtensions
    {
        public static string getValuePathParameters(this PathParametersEnum pathParameters)
        {
            return pathParameters switch
            {
                PathParametersEnum.KEY_TYPE => "{keyType}",
                PathParametersEnum.KEY_VALUE => "{keyValue}",
                _ => throw new ArgumentOutOfRangeException(nameof(pathParameters))
            };
        }
    }
}
