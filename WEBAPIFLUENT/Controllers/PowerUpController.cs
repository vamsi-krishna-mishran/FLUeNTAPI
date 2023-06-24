using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerUpController : ControllerBase
    {
        private readonly IPowerUpRepository _repo;
        public PowerUpController(IPowerUpRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int Id)
        {
            try
            {
                var res=await _repo.GetRange(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<PowerUpDTO> pu)
        {
            try
            {
                var res = await _repo.PostRange(pu);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message + ex.InnerException);
            }
        }

    }
}
