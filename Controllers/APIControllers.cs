using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


//test controllers just for testing

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // Sample in-memory data store
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1", Description = "First item" },
            new Item { Id = 2, Name = "Item2", Description = "Second item" }
        };

        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(items);
        }

        // GET: api/items/1
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item newItem)
        {
            if (newItem == null)
                return BadRequest("Item cannot be null");

            newItem.Id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
            items.Add(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        // PUT: api/items/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Item updatedItem)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
                return NotFound();

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;

            return NoContent(); // 204 No Content
        }

        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            items.Remove(item);

            return NoContent(); // 204 No Content
        }
    }

    // Sample model class for Item
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
