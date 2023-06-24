using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssembledBoardController : ControllerBase
    {
        private readonly IAssembledBoardRepository _repo;
        public AssembledBoardController(IAssembledBoardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int Id, [FromQuery]bool All)
        {
            try
            {
                if(All)
                {
                    var res=await _repo.GetAll(Id); return Ok(res);
                }
                else
                {
                    var res2=await _repo.Get(Id); return Ok(res2);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message+ex.InnerException);
            }
        }
        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] AssembledBoardDTO ab)
        {
            try
            {
                var res=await _repo.Add(ab); return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
        [HttpPost("PostAll")]
        public async Task<IActionResult> Post([FromBody] List<AssembledBoardDTO> ab)
        {
            try
            {
                var res = await _repo.AddRange(ab); return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id)
        {
            try
            {
                var res=await _repo.DeleteAll(Id); return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
    }
}
