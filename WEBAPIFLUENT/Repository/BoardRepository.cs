using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface IBoardRepository
    {
        public Task<int?> AddBoard(BoardDTO varintdto);
        public Task<int?> AddBoards(List<BoardDTO> Boarddto);
        public Task<int?> DeleteAll(int pid);
        public Task<int?> DeleteBoards(List<int> vids);
        public Task<int?> DeleteBoard(int vid);
        public Task<List<BoardDTO?>?> GetAll(int pid);
        public Task<List<BoardDTO?>?> GetBoards(List<int> ids);
        public Task<BoardDTO?> GetBoard(int id);
    }
    public class BoardRepository : IBoardRepository
    {
        private readonly PDFContext _context;
        public BoardRepository(PDFContext context)
        {
            _context = context;
        }

        public async Task<int?> AddBoard(BoardDTO varintdto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var Board = mapper.Map<Board>(varintdto);
            var res = await _context.boards.AddAsync(Board);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }
        public async Task<int?> AddBoards(List<BoardDTO> Boarddto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            List<Board> Boards = mapper.Map<List<Board>>(Boarddto);
            await _context.boards.AddRangeAsync(Boards);
            // var res = await _context.AddRangeAsync(Boards);
            await _context.SaveChangesAsync();

            // return res.Count;
            return Boards.Count;
        }
        public async Task<BoardDTO?> GetBoard(int id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.boards.FindAsync(id);
            return mapper.Map<BoardDTO>(res);
        }
        public async Task<List<BoardDTO?>?> GetBoards(List<int> ids)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.boards.Where(v => ids.Contains(v.Id)).ToListAsync();
            return mapper.Map<List<BoardDTO?>>(res);
        }
        public async Task<List<BoardDTO?>?> GetAll(int pid)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var res = await _context.boards.Where(v => v.VId == pid).ToListAsync();
            return mapper.Map<List<BoardDTO?>>(res);
        }
        public async Task<int?> DeleteBoard(int vid)
        {
            var res = await _context.boards.FindAsync(vid);
            if (res == null) return null;
            _context.boards.Remove(res);
            await _context.SaveChangesAsync();
            return res.Id;
        }
        public async Task<int?> DeleteBoards(List<int> vids)
        {
            var res = await _context.boards.Where(v => vids.Contains(v.Id)).ToListAsync();
            if (res == null) return null;
            _context.boards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }
        public async Task<int?> DeleteAll(int pid)
        {
            var res = await _context.boards.Where(v => v.VId == pid).ToListAsync();
            if (res == null) return null;
            _context.boards.RemoveRange(res);
            await _context.SaveChangesAsync();
            return res.Count;
        }


    }
}
