
using Invoice.Models;

namespace Invoice.Data
{
    public class CustomerStore
    {
        private static readonly CustomerStore _instance = new CustomerStore();
        private List<Customer> _customers = new List<Customer>();
        public static CustomerStore Instance => _instance;

        public List<Customer> GetCustomers() => _customers;

        public Customer GetCustomer(int id) => _customers.SingleOrDefault(c => c.Id == id);

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var index = _customers.FindIndex(c => c.Id == customer.Id);
            if (index >= 0)
            {
                _customers[index] = customer;
            }
        }

        public void RemoveCustomer(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
        public List<Customer> SearchCustomers(string term)
        {
            return _customers
                .Where(c => c.ContactName.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

}
