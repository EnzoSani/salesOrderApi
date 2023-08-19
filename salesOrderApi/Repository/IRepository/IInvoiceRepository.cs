using salesOrderApi.Entity;

namespace salesOrderApi.Repository.IRepository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceDetail>> GetAllInvoiceDetailByCode(string invoiceNo);
        Task<List<InvoiceHeader>> GetAllInvoiceHeader();
        Task<InvoiceHeader> GetInvoiceHeaderByCode(string invoiceNo);
        Task<ResponseType> Remove(string invoiceNo);
        Task<ResponseType> Save(InvoiceInput invoiceEntity);
    }
}
