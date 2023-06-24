using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface IXLSheetRepository
    {
        public Task<int?> AddTemplate(XLTemplateDTO dto);
        public Task<int?> RemoveTemplate(int XId);
        public Task<List<XLTemplateDTO>?> GetAllTemplates(int SHId);
        public  Task<int?> AddRangeSheet(List<XLSheetDTO> sheets);
        public  Task<List<XLSheetDTO>?> Getsheet(int XId);
    }
    public class XLSheetRepository:IXLSheetRepository
    {
        private readonly PDFContext _context;
        public XLSheetRepository(PDFContext context)
        {
            _context = context;
        }

        #region xltemplates
        public async Task<int?> AddTemplate(XLTemplateDTO dto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var data=mapper.Map<XLTamplate>(dto);
            var res = await _context.xLTamplates.AddAsync(data);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }
        public async Task<int?> RemoveTemplate(int XId)
        {

            var res = await _context.xLTamplates.FindAsync(XId);
            if (res == null) {
                return null;
            }
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<List<XLTemplateDTO>?> GetAllTemplates(int SHId)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res = await _context.xLTamplates.Where(xt => xt.SHId == SHId).ToListAsync();
            if(res == null)
            {
                return null;
            }
            return mapper.Map<List<XLTemplateDTO>>(res);
        }
        #endregion
        #region xlsheets

        public async Task<int?> AddRangeSheet(List<XLSheetDTO> sheets)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var data=mapper.Map<List<XLSheet>>(sheets);
            await _context.xLSheets.AddRangeAsync(data);
            await _context.SaveChangesAsync();
            return data.Count;
        }
        public async Task<List<XLSheetDTO>?> Getsheet(int XId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res=await _context.xLSheets.Where(xs=>xs.XId == XId).ToListAsync();
            if (res == null) { return null; }
            return mapper.Map<List<XLSheetDTO>>(res);
        }
        #endregion
    }
}
