using domain.models.openSearchModel;

namespace ApplicationCore.interfaces
{
    public interface IOpenSearchService
    {
        Task <OSDefinitive> SearchKey(string keyType, string keyValue);
        Task SaveKey(OSDefinitive osDefinitive);
    }
}
