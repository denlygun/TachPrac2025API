using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly List<string> Items = new() { "Item1", "Item2" };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() => Ok(Items);

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= Items.Count) return NotFound("Item not found");
            return Ok(Items[id]);
        }

        [HttpPost]
        public ActionResult Post([FromBody] string item)
        {
            Items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = Items.Count - 1 }, item);
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] string newItem)
        {
            if (id < 0 || id >= Items.Count) return NotFound("Item not found");
            Items[id] = newItem;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= Items.Count) return NotFound("Item not found");
            Items.RemoveAt(id);
            return NoContent();
        }
    }
}