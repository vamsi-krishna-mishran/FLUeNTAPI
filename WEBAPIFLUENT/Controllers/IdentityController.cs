using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityRepository _repo;

        public IdentityController(IIdentityRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<IdentitysController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IdentitysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IdentitysController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IdentityDTO vdto)
        {
            try
            {
                var res = await _repo.AddIdentity(vdto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("AddIdentitys")]
        public async Task<IActionResult> Post([FromBody] List<IdentityDTO> vdto)
        {
            try
            {
                var res = await _repo.AddIdentitys(vdto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<IdentitysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IdentitysController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _repo.DeleteIdentity(id);
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
                var res = await _repo.DeleteIdentitys(vdo);
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
