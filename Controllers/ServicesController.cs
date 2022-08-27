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
    public class ServicesController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;

        public ServicesController(Aladin_prp_dbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [Route("GetAll")]
        [HttpGet]
      public IActionResult GetAll()
        {
            var list = _context.Services.ToList();
            return Ok(list);
        }

        // GET: api/Services/5
        [Route("GetById")]
        [HttpGet]
        public IActionResult GetServicesById(string id)
        {
            var get = _context.Services.FirstOrDefault(s => s.Id == id);
            return Ok(get);
        }
        [Route("AddService")]
        [HttpPost]
        public IActionResult CreateService([FromBody] Service service)
        {
            if(ServiceExists(service.Id))
            {
                return BadRequest("alreadyexist");
            }
            else
            {
                this._context.Add<Service>(service);
                this._context.SaveChanges();
            }
            return Ok(service);
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("Dlete")]
        [HttpDelete]
        public IActionResult DeleteService(string id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if(service != null)
            {
                this._context.Remove(service);
            }
            return Ok();
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
          if (_context.Services == null)
          {
              return Problem("Entity set 'Aladin_prp_dbContext.Services'  is null.");
          }
            _context.Services.Add(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceExists(service.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
      /*  [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(string id)
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool ServiceExists(string id)
        {
            return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
