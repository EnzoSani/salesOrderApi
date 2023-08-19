using AutoMapper;
using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Entity;
using salesOrderApi.Models;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CustomerEntity>> getAll()
        {
          var customerData = await _dbContext.TblCustomers.ToListAsync();   
            if(customerData != null && customerData.Count>0)
            {
             var customerItem =  _mapper.Map<List<CustomerEntity>>(customerData);
             return customerItem;
            }
            return new List<CustomerEntity>();
        }

        public async Task<CustomerEntity> GetByCode(string code)
        {
            int c = Convert.ToInt32(code);
            var customerData = await _dbContext.TblCustomers.FirstOrDefaultAsync(item => item.Code == code);
            if(customerData != null)
            {
                return _mapper.Map<CustomerEntity>(customerData);
            }
            return new CustomerEntity();
        }
    }
    
}
