using salesOrderApi.Entity;
using salesOrderApi.Models;

namespace salesOrderApi.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerEntity>> getAll();
        Task<CustomerEntity> GetByCode(string code);
    }
}
