using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _repo;

        public BoardController(IBoardRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BoardsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BoardsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoardsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoardDTO vdto)
        {
            try
            {
                var res = await _repo.AddBoard(vdto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("AddBoards")]
        public async Task<IActionResult> Post([FromBody] List<BoardDTO> vdto)
        {
            try
            {
                var res = await _repo.AddBoards(vdto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<BoardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoardsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _repo.DeleteBoard(id);
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
                var res = await _repo.DeleteBoards(vdo);
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
