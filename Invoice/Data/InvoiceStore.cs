using Invoice.Models;

namespace Invoice.Data
{
    public class InvoiceStore
    {
        private static readonly InvoiceStore _instance = new InvoiceStore();
        private List<InvoiceModel> _InvoiceModel = new List<InvoiceModel>();
        private int _nextId = 0;


        public static InvoiceStore Instance => _instance;

        public List<InvoiceModel> GetInvoiceModel() => _InvoiceModel;

        public InvoiceModel GetInvoiceModel(int id) => _InvoiceModel.SingleOrDefault(c => c.Id == id);

        public int AddInvoiceModel(InvoiceModel customer)
        {
            customer.Id = _nextId++;
            _InvoiceModel.Add(customer);
            return customer.Id;
        }

        public void UpdateInvoiceModel(InvoiceModel customer)
        {
            var index = _InvoiceModel.FindIndex(c => c.Id == customer.Id);
            if (index >= 0)
            {
                _InvoiceModel[index] = customer;
            }
        }

        public void RemoveInvoiceModel(int id)
        {
            var customer = _InvoiceModel.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _InvoiceModel.Remove(customer);
            }
        }
    }
}
