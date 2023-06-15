using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarientController : ControllerBase
    {
        private readonly IVarientRepository _repo;

        public VarientController(IVarientRepository repo)
        {
            _repo = repo;
        }
        
        // GET: api/<VarientsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VarientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VarientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VarientDTO vdto)
        {
            try
            {
                var res=await _repo.AddVarient(vdto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("AddVarients")]
        public async Task<IActionResult> Post([FromBody] List<VarientDTO> vdto)
        {
            try
            {
                var res = await _repo.AddVarients(vdto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<VarientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VarientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res= await _repo.DeleteVarient(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpDelete("Some")]
        public async Task<IActionResult> Delete([FromBody]List<int> vdo)
        {
            try
            {
                var res = await _repo.DeleteVarients(vdo);
                return Ok(res);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500,ex.InnerException);   
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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
    }
}
