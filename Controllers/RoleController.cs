using AlaadinWebAPIs.Models;
using AlaadinWebAPIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roleRepo;
        public RoleController(IRole RoleRepo)
        {
            this._roleRepo= RoleRepo;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_roleRepo.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("ReadById")]
        [HttpGet]
        public IActionResult ReadById(string Id, Role role)
        {
            try
            {
                return Ok(_roleRepo.ReadById(Id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            }
            
        }
        [Route("AddRole")]
        [HttpPost]
        public IActionResult Post([FromBody] Role objAdd)
        {
            try
            {
                return Ok(_roleRepo.Add(objAdd));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }
    }
}
