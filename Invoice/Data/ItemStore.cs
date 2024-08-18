using Invoice.Models;

namespace Invoice.Data
{
    public class ItemStore
    {
        private static readonly ItemStore _instance = new ItemStore();
        private List<Item> _item = new List<Item>();



        public static ItemStore Instance => _instance;

        public List<Item> GetItems() => _item;

        public Item GetItem(int id) => _item.SingleOrDefault(c => c.Id == id);

        public void AddItem(Item customer)
        {
            _item.Add(customer);
        }

        public void UpdateItem(Item customer)
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
