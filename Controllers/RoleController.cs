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
            return Ok(_roleRepo.GetAll());
        }
        [Route("AddRole")]
        [HttpPost]
        public IActionResult Post(Role objAdd)
        {
            return Ok(_roleRepo.Add(objAdd));
        }
    }
}
