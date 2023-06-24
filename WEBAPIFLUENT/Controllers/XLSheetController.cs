using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XLSheetController : ControllerBase
    {
        private readonly IXLSheetRepository _repo;
        public XLSheetController(IXLSheetRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetTemplates")]
        public async Task<IActionResult> Get(int SHId)
        {
            try
            {
                var res = await _repo.GetAllTemplates(SHId);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message+ex.InnerException);
            }
        }
        [HttpGet("GetSheet")]
        public async Task<IActionResult> GetSheets(int XId)
        {
            try
            {
                var res=await _repo.Getsheet(XId); return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpPost("AddTemplate")]
        public async Task<IActionResult> Post([FromBody] XLTemplateDTO dto)
        {
            try
            {
                var res=await _repo.AddTemplate(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpPost("AddSheet")]
        public async Task<IActionResult> PostSheet([FromBody] List<XLSheetDTO> dto)
        {
            try
            {
                var res=await _repo.AddRangeSheet(dto);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        //trying to do both upload sheet and adding template at a time
        [HttpPost("Experimental")]
        public async Task<IActionResult> PostExp([FromBody] CompositeDTO dto)
        {
            try
            {
                XLTemplateDTO xldto = dto.Template;
                List<XLSheetDTO> xsdto = dto.Sheets;
                var res1=await _repo.AddTemplate(xldto);
                if(res1 == null)
                {
                    return StatusCode(500, "adding table template got failed.");
                }
                xsdto.ForEach(el =>
                {
                    el.XId = (int)res1;
                });
                var res2 = await _repo.AddRangeSheet(xsdto);
                return Ok(res2);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
        [HttpDelete("DeleteSheet")]
        public async Task<IActionResult> Delete([FromQuery]int XId)
        {
            try
            {
                var res = await _repo.RemoveTemplate(XId);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message + ex.InnerException);
            }
        }
    }
}
