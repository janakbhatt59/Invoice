using Invoice.Data;
using Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Invoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InvoiceStore _invoiceStore;

        public HomeController(ILogger<HomeController> logger, InvoiceStore invoiceStore)
        {
            _logger = logger;
            _invoiceStore = invoiceStore;
        }
        public IActionResult InvoiceSave(InvoiceModel modal)
        {
            _invoiceStore.AddInvoiceModel(modal);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var data = _invoiceStore.GetInvoiceModel();
            ViewBag.Invoices = data;
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
