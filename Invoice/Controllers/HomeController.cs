using Invoice.Data;
using Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;

namespace Invoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InvoiceStore _invoiceStore;
        private readonly InvoiceItemStore _invoiceItemStore;

        public HomeController(ILogger<HomeController> logger, InvoiceStore invoiceStore, InvoiceItemStore invoiceItemStore)
        {
            _logger = logger;
            _invoiceStore = invoiceStore;
            _invoiceItemStore = invoiceItemStore;
        }
        public IActionResult InvoiceSave(InvoiceModel invoiceModel, List<InvoiceItem> invoiceItems)
        {

            int id = _invoiceStore.AddInvoiceModel(invoiceModel);
            foreach (var item in invoiceItems)
            {
                item.InvoiceId = invoiceModel.Id; // Set the InvoiceId for each item
                _invoiceItemStore.AddItem(item);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var data = _invoiceStore.GetInvoiceModel();
            ViewBag.Invoices = data;
            return View();
        }
        public ActionAsPdf pdfStatement(int InvoiceId)
        {
            var data = _invoiceStore.GetInvoiceModel(InvoiceId);

            return new ActionAsPdf("Index");
        }
        public IActionResult InvoicePrint(InvoiceModel invoiceModel)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
