using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salesOrderApi.Entity;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterRepository _masterRepository;

        public MasterController(IMasterRepository customerRepository)
        {
            _masterRepository = customerRepository;
        }

        [HttpGet ("GetAllVariant/{type}")]
        public async Task<List<VariantEntity>> GetAllVariant(string type)
        {
            return await _masterRepository.GetAllVariant(type);
        }

        [HttpGet ("GetAllCategory")]
        public async Task<List<CategoryEntity>> GetAllCategories()
        {
            return await _masterRepository.GetCategory();
        }
    }
}
