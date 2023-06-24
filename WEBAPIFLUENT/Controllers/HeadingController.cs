using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadingController : ControllerBase
    {
        private readonly IHeadingRepository _repo;
        public HeadingController(IHeadingRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int Id)
        {
            try
            {
                var res = await _repo.GetAll(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HeadingDTO h)
        {
            try
            {
                var res=await _repo.Add(h);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
    }
}
