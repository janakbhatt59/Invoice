using Invoice.Data;
using Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerStore _store;

        public CustomerController(CustomerStore store)
        {
            _store = store;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_store.GetCustomers());
        }
        [HttpGet("search")]
        public IActionResult SearchCustomer(string term)
        {
         var customer = _store.SearchCustomers(term);
            return Ok(customer);
        }
        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _store.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            _store.AddCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var existingCustomer = _store.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _store.UpdateCustomer(customer);
            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _store.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _store.RemoveCustomer(id);
            return NoContent();
        }
    }
}