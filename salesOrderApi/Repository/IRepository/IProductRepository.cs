using salesOrderApi.Entity;

namespace salesOrderApi.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAll();
        Task<List<ProductEntity>> GetByCategory(int category);
        Task<ProductEntity> GetByCode(string code);
        Task<List<ProductVariantEntity>> GetVariantByProduct(string productCode);
        Task<ResponseType> SaveProduct(ProductEntity product);
        Task<bool> SaveProductVariant(ProductVariantEntity _variant, string productCode);
    }
}
