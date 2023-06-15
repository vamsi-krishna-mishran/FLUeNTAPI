using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;
using WEBAPIFLUENT.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        
        // GET: api/<ProductController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result=await _repo.GetProduct(id); return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] List<int>ids)
        {
            try
            {
                var res=await _repo.GetProducts(ids); return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            try
            {
                var result = await _repo.AddProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("addproducts")]
        public async Task<IActionResult> Post([FromBody]List<ProductDTO> ids)
        {
            try
            {
                var result = await _repo.AddProducts(ids);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _repo.DeleteProduct(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            try
            {
                var res = await _repo.DeleteProducts(ids);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
