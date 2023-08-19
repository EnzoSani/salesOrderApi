using AutoMapper;
using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Entity;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Repository
{
    public class MasterRepository :IMasterRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public MasterRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<VariantEntity>> GetAllVariant(string variantType)
        {
            var customerData = await _dbContext.TblMastervariants.Where(item=> item.VariantType == variantType).ToListAsync();
            if(customerData != null && customerData.Count > 0)
            {
                return _mapper.Map<List<VariantEntity>>(customerData);
            }
            return new List<VariantEntity>();
        }

        public async Task<List<CategoryEntity>> GetCategory()
        {
            var customerData = await _dbContext.TblCategories.ToListAsync();
            if(customerData != null && customerData.Count > 0)
            {
                return _mapper.Map<List<CategoryEntity>>(customerData);
            }
            return new List<CategoryEntity>();
        }
    }
}
