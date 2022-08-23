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
    public class ListingClaimsController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;

        public ListingClaimsController(Aladin_prp_dbContext context)
        {
            _context = context;
        }

        // GET: api/ListingClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingClaim>>> GetListingClaims()
        {
          if (_context.ListingClaims == null)
          {
              return NotFound();
          }
            return await _context.ListingClaims.ToListAsync();
        }

        // GET: api/ListingClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListingClaim>> GetListingClaim(string id)
        {
          if (_context.ListingClaims == null)
          {
              return NotFound();
          }
            var listingClaim = await _context.ListingClaims.FindAsync(id);

            if (listingClaim == null)
            {
                return NotFound();
            }

            return listingClaim;
        }

        // PUT: api/ListingClaims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListingClaim(string id, ListingClaim listingClaim)
        {
            if (id != listingClaim.Id)
            {
                return BadRequest();
            }

            _context.Entry(listingClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingClaimExists(id))
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

        // POST: api/ListingClaims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListingClaim>> PostListingClaim(ListingClaim listingClaim)
        {
          if (_context.ListingClaims == null)
          {
              return Problem("Entity set 'Aladin_prp_dbContext.ListingClaims'  is null.");
          }
            _context.ListingClaims.Add(listingClaim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListingClaimExists(listingClaim.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListingClaim", new { id = listingClaim.Id }, listingClaim);
        }

        // DELETE: api/ListingClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListingClaim(string id)
        {
            if (_context.ListingClaims == null)
            {
                return NotFound();
            }
            var listingClaim = await _context.ListingClaims.FindAsync(id);
            if (listingClaim == null)
            {
                return NotFound();
            }

            _context.ListingClaims.Remove(listingClaim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListingClaimExists(string id)
        {
            return (_context.ListingClaims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
