using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salesOrderApi.Entity;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet ("GetAllHeader")]
        public async Task<List<InvoiceHeader>> GetAllHeader()
        {
            return await _invoiceRepository.GetAllInvoiceHeader();
        }

        [HttpGet ("GetHeaderByCode")]
        public async Task<InvoiceHeader> GetInvoiceHeaderByCode(string invoiceNo)
        {
            return await _invoiceRepository.GetInvoiceHeaderByCode(invoiceNo);
        }

        [HttpGet ("GetAllDetailByCode")]
        public async Task<List<InvoiceDetail>> GetAllDetailByCode(string invoiceNo)
        {
            return await _invoiceRepository.GetAllInvoiceDetailByCode(invoiceNo);
        }

        [HttpPost ("Save")]
        public async Task<ResponseType> Save([FromBody] InvoiceInput invoiceEntity)
        {
            return await _invoiceRepository.Save(invoiceEntity);
        }


    }
}
