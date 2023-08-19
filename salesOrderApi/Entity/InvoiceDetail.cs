namespace salesOrderApi.Entity
{
    public class InvoiceDetail
    {
        public string InvoceNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string? ProductName { get; set; }
        public int? Qty { get; set; }
        public Decimal? SalesPrice { get; set; }
        public Decimal? Total { get; set; }

    }
}
