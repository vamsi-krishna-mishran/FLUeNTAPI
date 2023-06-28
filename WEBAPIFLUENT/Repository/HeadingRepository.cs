using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IHeadingRepository
    {
        public  Task<int?> Add(HeadingDTO hd);
        public  Task<HeadingDTO?> Get(int id);
        public  Task<List<HeadingDTO?>?> GetAll(int IId);
        public  Task<int?> Delete(int id);
    }
    public class HeadingRepository:IHeadingRepository
    {
        private readonly PDFContext _context;
        public HeadingRepository(PDFContext context)    
        {
            _context = context;
        }

        public async Task<int?> Add(HeadingDTO hd)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var h=mapper.Map<Heading>(hd);
            var find = await _context.headings.FindAsync(h.Id);
            if (find != null)
            {
                find.Description = hd.Description;
                find.Remark= hd.Remark;
                await _context.SaveChangesAsync();
                return find.Id;
            }

            var res=await _context.headings.AddAsync(h);
            await _context.SaveChangesAsync();

            return res.Entity.Id;
        }
        public async Task<HeadingDTO?> Get(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var h = await _context.headings.FindAsync(id);
            if (h == null) return null;
            return mapper.Map<HeadingDTO>(h);
        }
        public async Task<List<HeadingDTO?>?> GetAll(int IId)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res = await _context.headings.Where(h => h.IId == IId).ToListAsync();
            if(res.Count== 0) return null;  
            return mapper.Map<List<HeadingDTO?>?>(res);
        }
        public async Task<int?> Delete(int id)
        {
            var h = await _context.headings.FindAsync(id);
            if (h == null) return null;
            _context.headings.Remove(h);
            await _context.SaveChangesAsync();
            return h.Id;
        }

    }
}
