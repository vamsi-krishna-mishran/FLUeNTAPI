using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IVarientRepository
    {
        public Task<int?> AddVarient(VarientDTO varintdto);
        public Task<int?> AddVarients(List<VarientDTO> varientdto);
        public  Task<int?> DeleteAll(int pid);
        public Task<int?> DeleteVarients(List<int> vids);
        public Task<int?> DeleteVarient(int vid);
        public Task<List<VarientDTO?>?> GetAll(int pid);
        public Task<List<VarientDTO?>?> GetVarients(List<int> ids);
        public Task<VarientDTO?> GetVarient(int id);
    }
    public class VarientRepository:IVarientRepository
    {
        private readonly PDFContext _context;
        public VarientRepository(PDFContext context) { 
            _context = context;
        }

        public async Task<int?> AddVarient(VarientDTO varintdto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var varient=mapper.Map<Varient>(varintdto);
            var res=await _context.varients.AddAsync(varient);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }
        public async Task<int?> AddVarients(List<VarientDTO> varientdto)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            List<Varient> varients=mapper.Map<List<Varient>>(varientdto);
             await _context.varients.AddRangeAsync(varients);
           // var res = await _context.AddRangeAsync(varients);
            await _context.SaveChangesAsync();

            // return res.Count;
            return varients.Count;
        }
        public async Task<VarientDTO?> GetVarient(int id)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res = await _context.varients.FindAsync(id);
            return mapper.Map<VarientDTO>(res);
        }
        public async Task<List<VarientDTO?>?> GetVarients(List<int> ids)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res =await _context.varients.Where(v => ids.Contains(v.Id)).ToListAsync();
            return mapper.Map<List<VarientDTO?>>(res);
        }
        public async Task<List<VarientDTO?>?> GetAll(int pid)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res=await _context.varients.Where(v=>v.PId== pid).ToListAsync();
            return mapper.Map<List<VarientDTO?>>(res);
        }
        public async Task<int?> DeleteVarient(int vid)
        {
            var res = await _context.varients.FindAsync(vid);
            if (res == null) return null;
            _context.varients.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> DeleteVarients(List<int> vids)
        {
            var res = await _context.varients.Where(v => vids.Contains(v.Id)).ToListAsync();
            if(res==null) return null;
            _context.varients.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
        public async Task<int?> DeleteAll(int pid)
        {
            var res = await _context.varients.Where(v => v.PId == pid).ToListAsync();
            if(res==null) return null;
            _context.varients.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }

        
    }
}
