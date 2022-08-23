using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlaadinWebAPIs.Models;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldsController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;

        public CustomFieldsController(Aladin_prp_dbContext context)
        {
            _context = context;
        }

        // GET: api/CustomFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomField>>> GetCustomFields()
        {
          if (_context.CustomFields == null)
          {
              return NotFound();
          }
            return await _context.CustomFields.ToListAsync();
        }

        // GET: api/CustomFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomField>> GetCustomField(string id)
        {
          if (_context.CustomFields == null)
          {
              return NotFound();
          }
            var customField = await _context.CustomFields.FindAsync(id);

            if (customField == null)
            {
                return NotFound();
            }

            return customField;
        }

        // PUT: api/CustomFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomField(string id, CustomField customField)
        {
            if (id != customField.Id)
            {
                return BadRequest();
            }

            _context.Entry(customField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldExists(id))
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

        // POST: api/CustomFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomField>> PostCustomField(CustomField customField)
        {
          if (_context.CustomFields == null)
          {
              return Problem("Entity set 'Aladin_prp_dbContext.CustomFields'  is null.");
          }
            _context.CustomFields.Add(customField);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomFieldExists(customField.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomField", new { id = customField.Id }, customField);
        }

        // DELETE: api/CustomFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomField(string id)
        {
            if (_context.CustomFields == null)
            {
                return NotFound();
            }
            var customField = await _context.CustomFields.FindAsync(id);
            if (customField == null)
            {
                return NotFound();
            }

            _context.CustomFields.Remove(customField);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomFieldExists(string id)
        {
            return (_context.CustomFields?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
