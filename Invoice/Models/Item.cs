namespace Invoice.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Code {  get; set; }
        public string Name { get; set; }
        public bool TrackInventory { get; set; }
        public bool AddToPurchase { get; set; }
        public bool AddToSell { get; set; }
        public decimal SalePrice { get; set; }
        public int SaleAccount { get; set;}
        public string TaxRate { get; set;}
        public string Description { get; set;}
    }
}
