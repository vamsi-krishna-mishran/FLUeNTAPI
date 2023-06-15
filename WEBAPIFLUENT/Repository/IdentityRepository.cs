using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface IIdentityRepository
    {
        public Task<int?> AddIdentity(IdentityDTO varintdto);
        public Task<int?> AddIdentitys(List<IdentityDTO> Identitydto);
        public Task<int?> DeleteAll(int pid);
        public Task<int?> DeleteIdentitys(List<int> vids);
        public Task<int?> DeleteIdentity(int vid);
        public Task<List<IdentityDTO?>?> GetAll(int pid);
        public Task<List<IdentityDTO?>?> GetIdentitys(List<int> ids);
        public Task<IdentityDTO?> GetIdentity(int id);
    }
    public class IdentityRepository : IIdentityRepository
    {
        private readonly PDFContext _context;
        public IdentityRepository(PDFContext context)
        {
            _context = context;
        }

        public async Task<int?> AddIdentity(IdentityDTO varintdto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var Identity = mapper.Map<Identity>(varintdto);
            var res = await _context.identity.AddAsync(Identity);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }
        public async Task<int?> AddIdentitys(List<IdentityDTO> Identitydto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            List<Identity> Identitys = mapper.Map<List<Identity>>(Identitydto);
            await _context.identity.AddRangeAsync(Identitys);
            // var res = await _context.AddRangeAsync(Identitys);
            await _context.SaveChangesAsync();

            // return res.Count;
            return Identitys.Count;
        }
        public async Task<IdentityDTO?> GetIdentity(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.identity.FindAsync(id);
            return mapper.Map<IdentityDTO>(res);
        }
        public async Task<List<IdentityDTO?>?> GetIdentitys(List<int> ids)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.identity.Where(v => ids.Contains(v.Id)).ToListAsync();
            return mapper.Map<List<IdentityDTO?>>(res);
        }
        public async Task<List<IdentityDTO?>?> GetAll(int pid)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.identity.Where(v => v.RId == pid).ToListAsync();
            return mapper.Map<List<IdentityDTO?>>(res);
        }
        public async Task<int?> DeleteIdentity(int vid)
        {
            var res = await _context.identity.FindAsync(vid);
            if (res == null) return null;
            _context.identity.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> DeleteIdentitys(List<int> vids)
        {
            var res = await _context.identity.Where(v => vids.Contains(v.Id)).ToListAsync();
            if (res == null) return null;
            _context.identity.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
        public async Task<int?> DeleteAll(int pid)
        {
            var res = await _context.identity.Where(v => v.RId == pid).ToListAsync();
            if (res == null) return null;
            _context.identity.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }


    }
}
