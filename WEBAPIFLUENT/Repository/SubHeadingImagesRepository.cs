using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface ISubHeadingImagesRepository
    {
        public  Task<List<SubHeadingImagesDTO>?> GetAll(int SHId);
        public Task<int?> Delete(int Id);
        public  Task<int?> Add(SubHeadingImagesDTO dto);
    }
    
    public class SubHeadingImagesRepository:ISubHeadingImagesRepository
    {
        private readonly PDFContext _context;
        public SubHeadingImagesRepository(PDFContext context)
        {
            _context = context;
        }
        public async Task<List<SubHeadingImagesDTO>?> GetAll(int SHId)
        {
            var res=await _context.subheadingimages.Where(img=>img.SHId == SHId).ToListAsync();
            var mapper = MapperConfig.InitializeAutomapper();
            if(res==null)return null;
            return mapper.Map<List<SubHeadingImagesDTO>>(res);

        }
        public async Task<int?> Delete(int Id)
        {
            var res = await _context.subheadingimages.FindAsync(Id);
            if(res==null) return null;
             _context.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> Add(SubHeadingImagesDTO dto)
        {
            var mapper= MapperConfig.InitializeAutomapper();
            var res = mapper.Map<SubHeadingImages>(dto);
            var find = await _context.subheadingimages.FindAsync(res.Id);
            if (find != null)
            {
                find.Name = res.Name;
                find.ImageData = res.ImageData;
                await _context.SaveChangesAsync();
                return find.Id;
            }
            var res3=await _context.subheadingimages.AddAsync(res);
            await _context.SaveChangesAsync();
            return res3.Entity.Id;
        }
    }
}
