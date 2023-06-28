using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    public interface IPowerUpRepository
    {
        public  Task<List<PowerUpDTO?>?> GetRange(int Id);
        public Task<int?> PostRange(List<PowerUpDTO> pud);
    }
    
    public class PowerUpRepository:IPowerUpRepository
    {
        private readonly PDFContext _context;
        public PowerUpRepository(PDFContext context)
        {
            _context = context;
        }
        public async Task<List<PowerUpDTO?>?>  GetRange(int Id)
        {
            var res = await _context.poweruptests.Where(pu => pu.IId == Id).ToListAsync();
            if (res.Count == 0) return null;
            var mapper=MapperConfig.InitializeAutomapper();
            return mapper.Map<List<PowerUpDTO?>?>(res);
        }
        public async Task<int?> PostRange(List<PowerUpDTO> pud)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var pud2 = mapper.Map<List<PowerUpTest>>(pud);
            var find = await _context.poweruptests.Where(pu => pu.IId == pud2.First().IId).ToListAsync();
            if (find.Count!=0)
            {
                _context.RemoveRange(find);
                await _context.SaveChangesAsync();
            }
            await _context.poweruptests.AddRangeAsync(pud2);
            await _context.SaveChangesAsync();
            return pud2.Count;
        }
    }
}
