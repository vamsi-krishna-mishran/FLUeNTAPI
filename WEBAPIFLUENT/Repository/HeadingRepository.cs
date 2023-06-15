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
        public  Task<Heading?> Get(int id);
        public  Task<List<Heading?>?> GetAll(int IId);
        public  Task<int?> Delete(int id);
    }
    public class HeadingRepository
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
            var res=await _context.headings.AddAsync(h);
            await _context.SaveChangesAsync();

            return res.Entity.Id;
        }
        public async Task<Heading?> Get(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var h = await _context.headings.FindAsync(id);
            if (h == null) return null;
            return mapper.Map<Heading>(h);
        }
        public async Task<List<Heading?>?> GetAll(int IId)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res = await _context.headings.Where(h => h.IId == IId).ToListAsync();
            return mapper.Map<List<Heading?>?>(res);
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
