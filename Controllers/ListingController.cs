using AlaadinWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;
        public ListingController(Aladin_prp_dbContext context)
        {
            _context = context;
        }
        
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                if(Listing.Equals != null)
                {
                    return Ok(_context.Listings.ToList());
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [Route("GetListingId")]
        [HttpGet]
        public IActionResult GetByListingId(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var user = _context.Listings.FirstOrDefault(x => x.Id == id);
                    return Ok(user);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [Route("GetbyUserId")]
        [HttpGet]
        public IActionResult GetByUserId(string UserId)
        {
            try
            {
                if (!string.IsNullOrEmpty(UserId))
                {
                    var user = _context.Listings.FirstOrDefault(x => x.UserId == UserId);
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [Route("V1/Search")]
        [HttpGet]
        public IActionResult Search(string title)
        {
            try
            {
                if ( _context.Listings!= null)
                {
                   var res = _context.Listings.FirstOrDefault(x => x.Title == title);
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
            return Ok();
        }
    }
}
