using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubHeadingImagesController : ControllerBase
    {
        private readonly ISubHeadingImagesRepository _repo;
        public SubHeadingImagesController(ISubHeadingImagesRepository repo)
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
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id)
        {
            try
            {
                var res = await _repo.Delete(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);

            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubHeadingImagesDTO dto)
        {
            try
            {
                var res = await _repo.Add(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);

            }
        }
    }
}
