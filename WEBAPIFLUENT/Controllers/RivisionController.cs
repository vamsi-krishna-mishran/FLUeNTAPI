using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RivisionController : ControllerBase
    {
        private readonly IRivisionRepository _repo;

        public RivisionController(IRivisionRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<RivisionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RivisionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RivisionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RivisionDTO vdto)
        {
            try
            {
                var res = await _repo.AddRivision(vdto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("AddRivisions")]
        public async Task<IActionResult> Post([FromBody] List<RivisionDTO> vdto)
        {
            try
            {
                var res = await _repo.AddRivisions(vdto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<RivisionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RivisionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _repo.DeleteRivision(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpDelete("Some")]
        public async Task<IActionResult> Delete([FromBody] List<int> vdo)
        {
            try
            {
                var res = await _repo.DeleteRivisions(vdo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpDelete("All")]
        public async Task<IActionResult> DDelete([FromBody] int pid)
        {
            try
            {
                var res = await _repo.DeleteAll(pid);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
    }
}
