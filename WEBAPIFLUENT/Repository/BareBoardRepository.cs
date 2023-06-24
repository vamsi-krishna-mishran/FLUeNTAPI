using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Enums;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IBareBoardRepository
    {
        public Task<int?> Add(BareBoardDTO bbd);
        public Task<int?> AddRange(List<BareBoardDTO> bbd);
        public Task<BareBoardDTO?> Get(int id,BoardType boardType);
        public Task<List<BareBoardDTO?>?> GetSome(List<int> ids);
        public Task<List<BareBoardDTO?>?> GetAll(int IId);
        public Task<int?> Delete(int Id);
        public Task<int?> DeleteAll(int IId);
        public Task<int?> DeleteSome(List<int> ids);
    }
    public class BareBoardRepository:IBareBoardRepository
    {
        private readonly PDFContext _context;
        public BareBoardRepository(PDFContext context)
        {
            _context = context;
        }
        public async Task<int?> Add(BareBoardDTO bbd)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var bb=mapper.Map<BareBoardDetails>(bbd);
            var boardIfalreadyExist=await _context.bareboards.Where(board=>board.IId==bbd.IId && board.BoardType==bbd.BoardType).FirstOrDefaultAsync();
            if (boardIfalreadyExist == null)
            {
                var res = await _context.bareboards.AddAsync(bb);
                await _context.SaveChangesAsync();

                return res.Entity.Id;
            }
            else
            {
                boardIfalreadyExist.ImageData = bbd.ImageData;
                boardIfalreadyExist.ImageName = bbd.ImageName;
                boardIfalreadyExist.Description = bbd.Description;
                await _context.SaveChangesAsync();
                return boardIfalreadyExist.Id;
            }
           
        }
        public async Task<int?> AddRange(List<BareBoardDTO> bbd)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var bb = mapper.Map<List<BareBoardDetails>>(bbd);
            await _context.bareboards.AddRangeAsync(bb);
            await _context.SaveChangesAsync();
            return bb.Count;
        }
        public async Task<BareBoardDTO?> Get(int id,BoardType boardType)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res =await  _context.bareboards.Where(b=>b.IId==id &&b.BoardType==boardType).FirstOrDefaultAsync();
            return mapper.Map<BareBoardDTO>(res);
        }
        public async Task<List<BareBoardDTO?>?> GetSome(List<int> ids)
        {
            var mapper=MapperConfig.InitializeAutomapper();
            var res =await  _context.bareboards.Where(bb => ids.Contains(bb.Id)).ToListAsync();
            return mapper.Map<List<BareBoardDTO?>?>(res);
        }
        public async Task<List<BareBoardDTO?>?> GetAll(int IId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.bareboards.Where(bb => bb.IId==IId).ToListAsync();
            return mapper.Map<List<BareBoardDTO?>?>(res);
        }
        public async Task<int?> Delete(int Id)
        {
            var res = await _context.bareboards.FindAsync(Id);
            if (res == null) return null;
            _context.bareboards.Remove(res);
           await  _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> DeleteAll(int IId)
        {
            var res=await _context.bareboards.Where(bb=>bb.IId==IId).ToListAsync(); 
            if(res==null)return null;
            _context.bareboards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
        public async Task<int?> DeleteSome(List<int> ids)
        {
            var res=await _context.bareboards.Where(bb=>ids.Contains(bb.IId)).ToListAsync();
            if(res==null)return null;
            _context.bareboards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
    }
}
