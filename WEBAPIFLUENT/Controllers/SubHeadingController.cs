using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubHeadingController : ControllerBase
    {
        private readonly ISubHeadingRepository _repo;
        public SubHeadingController(ISubHeadingRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int Id)
        {
            try
            {
                var res=await _repo.GetAll(Id); return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubHeadingDTO sh)
        {
            try
            {
                var res=await _repo.Add(sh);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
    }
}
