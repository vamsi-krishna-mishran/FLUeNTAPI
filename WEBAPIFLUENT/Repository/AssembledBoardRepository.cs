using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface IAssembledBoardRepository
    {
        public Task<int?> Add(AssembledBoardDTO bbd);
        public Task<int?> AddRange(List<AssembledBoardDTO> bbd);
        public Task<AssembledBoardDTO?> Get(int id);
        public Task<List<AssembledBoardDTO?>?> GetSome(List<int> ids);
        public Task<List<AssembledBoardDTO?>?> GetAll(int IId);
        public Task<int?> Delete(int Id);
        public Task<int?> DeleteAll(int IId);
        public Task<int?> DeleteSome(List<int> ids);
    }
    public class AssembledBoardRepository:IAssembledBoardRepository
    {
        private readonly PDFContext _context;
        public AssembledBoardRepository(PDFContext context)
        {
            _context = context;
        }
        public async Task<int?> Add(AssembledBoardDTO bbd)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var bb = mapper.Map<AssembledBoardDetails>(bbd);
            var res = await _context.assembledBoards.AddAsync(bb);
            await _context.SaveChangesAsync();

            return res.Entity.Id;
        }
        public async Task<int?> AddRange(List<AssembledBoardDTO> bbd)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var bb = mapper.Map<List<AssembledBoardDetails>>(bbd);
            await _context.assembledBoards.AddRangeAsync(bb);
            await _context.SaveChangesAsync();
            return bb.Count;
        }
        public async Task<AssembledBoardDTO?> Get(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.assembledBoards.FindAsync(id);
            return mapper.Map<AssembledBoardDTO>(res);
        }
        public async Task<List<AssembledBoardDTO?>?> GetSome(List<int> ids)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.assembledBoards.Where(bb => ids.Contains(bb.Id)).ToListAsync();
            return mapper.Map<List<AssembledBoardDTO?>?>(res);
        }
        public async Task<List<AssembledBoardDTO?>?> GetAll(int IId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.assembledBoards.Where(bb => bb.IId == IId).ToListAsync();
            return mapper.Map<List<AssembledBoardDTO?>?>(res);
        }
        public async Task<int?> Delete(int Id)
        {
            var res = await _context.assembledBoards.FindAsync(Id);
            if (res == null) return null;
            _context.assembledBoards.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> DeleteAll(int IId)
        {
            var res = await _context.assembledBoards.Where(bb => bb.IId == IId).ToListAsync();
            if (res == null) return null;
            _context.assembledBoards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
        public async Task<int?> DeleteSome(List<int> ids)
        {
            var res = await _context.assembledBoards.Where(bb => ids.Contains(bb.IId)).ToListAsync();
            if (res == null) return null;
            _context.assembledBoards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
    }
}

