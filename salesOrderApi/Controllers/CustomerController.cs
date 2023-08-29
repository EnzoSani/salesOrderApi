using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Entity;
using salesOrderApi.Models;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet ("GetAll")]
        public async Task<List<CustomerEntity>>GetAll()
        {
            return await _customerRepository.getAll();
        }

        [HttpGet("GetByCode")]
        public async Task<CustomerEntity> GetByCode(string code)
        {
            return await _customerRepository.GetByCode(code);
        }

    }

    
}
