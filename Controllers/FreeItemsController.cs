using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _4FreeApp.Data;
using _4FreeApp.Models;

namespace _4FreeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeItemsController : ControllerBase
    {
        private readonly FreeItemContext _context;

        public FreeItemsController(FreeItemContext context)
        {
            _context = context;
        }

        // GET: api/FreeItems
        [HttpGet]
        public IEnumerable<FreeItem> GetFreeItems()
        {
            return _context.FreeItems;
        }

        // GET: api/FreeItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreeItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var freeItem = await _context.FreeItems.FindAsync(id);

            if (freeItem == null)
            {
                return NotFound();
            }

            return Ok(freeItem);
        }

        // PUT: api/FreeItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreeItem([FromRoute] int id, [FromBody] FreeItem freeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != freeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(freeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreeItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FreeItems
        [HttpPost]
        public async Task<IActionResult> PostFreeItem([FromBody] FreeItem freeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FreeItems.Add(freeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFreeItem", new { id = freeItem.Id }, freeItem);
        }

        // DELETE: api/FreeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreeItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var freeItem = await _context.FreeItems.FindAsync(id);
            if (freeItem == null)
            {
                return NotFound();
            }

            _context.FreeItems.Remove(freeItem);
            await _context.SaveChangesAsync();

            return Ok(freeItem);
        }

        private bool FreeItemExists(int id)
        {
            return _context.FreeItems.Any(e => e.Id == id);
        }
    }
}