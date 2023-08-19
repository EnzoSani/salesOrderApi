using salesOrderApi.Entity;

namespace salesOrderApi.Repository.IRepository
{
    public interface IMasterRepository
    {
        Task<List<VariantEntity>> GetAllVariant(string variantType);
        Task<List<CategoryEntity>> GetCategory();
    }
}
