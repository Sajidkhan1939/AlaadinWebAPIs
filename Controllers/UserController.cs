using AlaadinWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;
        public UserController(Aladin_prp_dbContext context)
        {
            _context = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
           
            try
            {
                if (User != null)
                {
                    var get = _context.Users.ToList();
                    return Ok(get);
                }
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
            return Ok(true);
        }
        [Route("GetbyUserId")]
        [HttpGet]
        public IActionResult GetbyUserId(string id)
        {
            // var get = _context.Users.FirstOrDefault(s=>s.Id==id);
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                   
                    var user = _context.Users.FirstOrDefault(x => x.Id == id);
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(true);
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Post(User objuser)
        {
            var create = _context.Users.FirstOrDefault(s=>s.Id==objuser.Id);
            try
            {
                if (User != null)
                {
                    create.FirstName = objuser.FirstName;
                    create.Email = objuser.Email;
                    create.LastName = objuser.LastName;
                    create.Password = objuser.Password;
                    create.IdCard = objuser.IdCard;
                    create.PhoneNo = objuser.PhoneNo;
                    create.Servicetype = objuser.Servicetype;
                    create.StreetAddress = objuser.StreetAddress;
                    create.LocalName = objuser.LocalName;
                    create.Tehsil = objuser.Tehsil;
                    create.AccountStatus = objuser.AccountStatus;
                    create.AvailabilityStatus = objuser.AvailabilityStatus;
                    create.State = objuser.State;
                    create.Lattitude = objuser.Lattitude;
                    create.CreatedDate = objuser.CreatedDate;
                    create.LastModifiedDate = objuser.LastModifiedDate;
                    create.ProfilePhoto = objuser.ProfilePhoto;
                    create.CoverPhoto = objuser.CoverPhoto;
                    create.FirstName = objuser.About;
                    _context.SaveChanges();
                }
                else if (!string.IsNullOrWhiteSpace(objuser.Email))
                {

                    return Ok(" Email is not valid ");
                }
                else if (UserAlreadyExists(objuser.Email))
                {
                    return Ok("Email Already Exist");
                }   
                else
                {
                    Guid id = Guid.NewGuid();
                    _context.Users.Add(objuser);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                return BadRequest("Smething wrong");
            }
            
            
           return Ok();
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var delete = _context.Users.FirstOrDefault(s=>s.Id == id);
            if (!string.IsNullOrWhiteSpace(id))
            {
                _context.Users.Remove(delete);
                _context.SaveChanges();
            }
            return Ok(true);
        }
        private bool UserAlreadyExists(string email)
        {
            return (_context.Users?.Any(e => e.Email == email)).GetValueOrDefault();
        }
    }
}
