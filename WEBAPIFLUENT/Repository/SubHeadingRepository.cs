using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface ISubHeadingRepository
    {
        public Task<int?> Add(SubHeadingDTO hd);
        public Task<SubHeadingDTO?> Get(int id);
        public Task<List<SubHeadingDTO?>?> GetAll(int IId);
        public Task<int?> Delete(int id);
    }
    public class SubHeadingRepository:ISubHeadingRepository
    {
        private readonly PDFContext _context;
        public SubHeadingRepository(PDFContext context)
        {
            _context = context;
        }

        public async Task<int?> Add(SubHeadingDTO hd)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var h = mapper.Map<SubHeading>(hd);
            var find=await _context.subheading.FindAsync(h.Id);
            if(find != null) {
                find.Description = hd.Description;
                find.Remark = hd.Remark;
                await _context.SaveChangesAsync();
                return find.Id;

            }
            var res = await _context.subheading.AddAsync(h);
            await _context.SaveChangesAsync();

            return res.Entity.Id;
        }
        public async Task<SubHeadingDTO?> Get(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var h = await _context.subheading.FindAsync(id);
            if (h == null) return null;
            return mapper.Map<SubHeadingDTO>(h);
        }
        public async Task<List<SubHeadingDTO?>?> GetAll(int HId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.subheading.Where(h => h.HId == HId).ToListAsync();
            return mapper.Map<List<SubHeadingDTO?>?>(res);
        }
        public async Task<int?> Delete(int id)
        {
            var h = await _context.subheading.FindAsync(id);
            if (h == null) return null;
            _context.subheading.Remove(h);
            await _context.SaveChangesAsync();
            return h.Id;
        }


    }
}
