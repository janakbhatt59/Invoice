namespace Invoice.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string Reference { get; set; }
        public string PaymentType { get; set; }
        public string Currency {  get; set; }
        public string AmountTaxType { get; set; }
        public List<IFormFile> Attachment { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
