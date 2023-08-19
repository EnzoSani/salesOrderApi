namespace salesOrderApi.Entity
{
    public class InvoiceEntity
    {
        public InvoiceHeader? Header { get; set; }
        public List<InvoiceDetail>? details { get; set; }
    }
}
