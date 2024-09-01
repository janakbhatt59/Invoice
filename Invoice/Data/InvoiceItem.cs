using Invoice.Models;

namespace Invoice.Data
{
    public class InvoiceItemStore
    {
        private static readonly InvoiceItemStore _instance = new InvoiceItemStore();
        private List<InvoiceItem> _item = new List<InvoiceItem>();
        private int _nextId = 0;


        public static InvoiceItemStore Instance => _instance;

        public List<InvoiceItem> GetItems() => _item;

        public InvoiceItem GetItem(int id) => _item.SingleOrDefault(c => c.Id == id);

        public void AddItem(InvoiceItem customer)
        {
            customer.Id = ++_nextId;
            _item.Add(customer);
        }

        public void UpdateItem(InvoiceItem customer)
        {
            var index = _item.FindIndex(c => c.Id == customer.Id);
            if (index >= 0)
            {
                _item[index] = customer;
            }
        }

        public void RemoveItem(int id)
        {
            var customer = _item.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _item.Remove(customer);
            }
        }
    }
}
