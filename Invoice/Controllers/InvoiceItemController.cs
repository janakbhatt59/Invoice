using Invoice.Data;
using Invoice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly InvoiceItemStore _store;

        public InvoiceItemController(InvoiceItemStore store)
        {
            _store = store;
        }

        // GET: api/Item
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(_store.GetItems());
        }
        //[HttpGet("search")]
        //public IActionResult SearchItems(string term)
        //{
        //    var items = _store.SearchItems(term);
        //    return Ok(items);
        //}

        // GET: api/Item/5
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var Item = _store.GetItem(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(Item);
        }

        // POST: api/Item
        [HttpPost]
        public ActionResult<Item> PostItem(InvoiceItem Item)
        {
            _store.AddItem(Item);
            return CreatedAtAction(nameof(GetItem), new { id = Item.Id }, Item);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, InvoiceItem Item)
        {
            if (id != Item.Id)
            {
                return BadRequest();
            }

            var existingItem = _store.GetItem(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _store.UpdateItem(Item);
            return NoContent();
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var existingItem = _store.GetItem(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _store.RemoveItem(id);
            return NoContent();
        }
    }
}
