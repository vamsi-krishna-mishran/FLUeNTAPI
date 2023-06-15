using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    //public class RivisionRepository
    //{
        public interface IRivisionRepository
        {
            public Task<int?> AddRivision(RivisionDTO varintdto);
            public Task<int?> AddRivisions(List<RivisionDTO> Rivisiondto);
            public Task<int?> DeleteAll(int pid);
            public Task<int?> DeleteRivisions(List<int> vids);
            public Task<int?> DeleteRivision(int vid);
            public Task<List<RivisionDTO?>?> GetAll(int pid);
            public Task<List<RivisionDTO?>?> GetRivisions(List<int> ids);
            public Task<RivisionDTO?> GetRivision(int id);
        }
        public class RivisionRepository : IRivisionRepository
        {
            private readonly PDFContext _context;
            public RivisionRepository(PDFContext context)
            {
                _context = context;
            }

            public async Task<int?> AddRivision(RivisionDTO varintdto)
            {
                var mapper = MapperConfig.InitializeAutomapper();
                var Rivision = mapper.Map<Rivision>(varintdto);
                var res = await _context.rivisions.AddAsync(Rivision);
                await _context.SaveChangesAsync();
                return res.Entity.Id;
            }
            public async Task<int?> AddRivisions(List<RivisionDTO> Rivisiondto)
            {
                var mapper = MapperConfig.InitializeAutomapper();
                List<Rivision> Rivisions = mapper.Map<List<Rivision>>(Rivisiondto);
                await _context.rivisions.AddRangeAsync(Rivisions);
                // var res = await _context.AddRangeAsync(Rivisions);
                await _context.SaveChangesAsync();

                // return res.Count;
                return Rivisions.Count;
            }
            public async Task<RivisionDTO?> GetRivision(int id)
            {
                var mapper = MapperConfig.InitializeAutomapper();
                var res = await _context.rivisions.FindAsync(id);
                return mapper.Map<RivisionDTO>(res);
            }
            public async Task<List<RivisionDTO?>?> GetRivisions(List<int> ids)
            {
                var mapper = MapperConfig.InitializeAutomapper();
                var res = await _context.rivisions.Where(v => ids.Contains(v.Id)).ToListAsync();
                return mapper.Map<List<RivisionDTO?>>(res);
            }
            public async Task<List<RivisionDTO?>?> GetAll(int pid)
            {
                var mapper = MapperConfig.InitializeAutomapper();
                var res = await _context.rivisions.Where(v => v.BId == pid).ToListAsync();
                return mapper.Map<List<RivisionDTO?>>(res);
            }
            public async Task<int?> DeleteRivision(int vid)
            {
                var res = await _context.rivisions.FindAsync(vid);
                if (res == null) return null;
                _context.rivisions.Remove(res);
                await _context.SaveChangesAsync();
                return res.Id;
            }
            public async Task<int?> DeleteRivisions(List<int> vids)
            {
                var res = await _context.rivisions.Where(v => vids.Contains(v.Id)).ToListAsync();
                if (res == null) return null;
                _context.rivisions.RemoveRange(res);
                await _context.SaveChangesAsync();
                return res.Count;
            }
            public async Task<int?> DeleteAll(int pid)
            {
                var res = await _context.rivisions.Where(v => v.BId == pid).ToListAsync();
                if (res == null) return null;
                _context.rivisions.RemoveRange(res);
                await _context.SaveChangesAsync();
                return res.Count;
            }

       }
   // }
}
