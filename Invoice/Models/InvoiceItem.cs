namespace Invoice.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public int TaxRateId { get; set; }
        public string TaxRateName { get; set; }
        public decimal Amount { get; set; }

    }
}
