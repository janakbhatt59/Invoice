namespace Invoice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string BillingLine { get; set; }
        public string BillingCity { get; set; }
        public string BillingRegion { get; set;}
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set;}
        public string DeliveryLine { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryRegion { get; set;}
        public string DeliveryPostalCode { get; set; }
        public string DeliveryCountry { get; set;}
    }
}
