using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Enums;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BareBoardController : ControllerBase
    {
        private readonly IBareBoardRepository _repo;
        public BareBoardController(IBareBoardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int Id,  [FromQuery]string IBoardType="Bareboard")
        {
            try
            {
                if(!Enum.TryParse<BoardType>(IBoardType, out var boardType))
                {
                    return BadRequest("Invalid Board Type");
                }
                var res2=await _repo.Get(Id,boardType);
                return Ok(res2);
               
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
        
        public async Task<IActionResult> Post([FromBody] BareBoardDTO bb)
        {
            try
            {
                var res=await _repo.Add(bb);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
    }
}
