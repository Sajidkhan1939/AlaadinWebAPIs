using AlaadinWebAPIs.Models;
using AlaadinWebAPIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IRole _roleRepo;
        public ListingController(IRole RoleRepo)
        {
            this._roleRepo= RoleRepo;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleRepo.GetAll());
        }
    }
}
