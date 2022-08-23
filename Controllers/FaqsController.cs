﻿using System;
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
    public class FaqsController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;

        public FaqsController(Aladin_prp_dbContext context)
        {
            _context = context;
        }

        // GET: api/Faqs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faq>>> GetFaqs()
        {
          if (_context.Faqs == null)
          {
              return NotFound();
          }
            return await _context.Faqs.ToListAsync();
        }

        // GET: api/Faqs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faq>> GetFaq(string id)
        {
          if (_context.Faqs == null)
          {
              return NotFound();
          }
            var faq = await _context.Faqs.FindAsync(id);

            if (faq == null)
            {
                return NotFound();
            }

            return faq;
        }

        // PUT: api/Faqs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(string id, Faq faq)
        {
            if (id != faq.Id)
            {
                return BadRequest();
            }

            _context.Entry(faq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaqExists(id))
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

        // POST: api/Faqs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Faq>> PostFaq(Faq faq)
        {
          if (_context.Faqs == null)
          {
              return Problem("Entity set 'Aladin_prp_dbContext.Faqs'  is null.");
          }
            _context.Faqs.Add(faq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FaqExists(faq.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFaq", new { id = faq.Id }, faq);
        }

        // DELETE: api/Faqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(string id)
        {
            if (_context.Faqs == null)
            {
                return NotFound();
            }
            var faq = await _context.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaqExists(string id)
        {
            return (_context.Faqs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
