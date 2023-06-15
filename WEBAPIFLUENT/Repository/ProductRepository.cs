using Microsoft.EntityFrameworkCore;
using System.Linq;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IProductRepository
    {
        public Task<int> AddProduct(ProductDTO product);
        public Task<int> AddProducts(List<ProductDTO> product);
        public  Task<ProductDTO?> GetProduct(int pid);
        public Task<List<ProductDTO>?> GetProducts(List<int> pids);
        public  Task<int?> DeleteProduct(int pid);
        public  Task<int?> DeleteProducts(List<int> pids);
    }
    public class ProductRepository:IProductRepository
    {
        private readonly PDFContext _context;
       
        public ProductRepository(PDFContext context)
        {
            _context = context;
        }
        public async Task<int> AddProduct(ProductDTO product)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var prod=mapper.Map<Product>(product);
            var result=await _context.AddAsync<Product>(prod);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
        public async Task<int> AddProducts (List<ProductDTO> products)
        {
            //try
            //{
                var mapper = MapperConfig.InitializeAutomapper();
                var prod = mapper.Map<List<Product>>(products);
                await _context.AddRangeAsync(prod);
                await _context.SaveChangesAsync();
                return prod.Count;
           // }
           // catch (Exception ex)
           // {
            //    return 0;
           // }
        }
        public async Task<ProductDTO?> GetProduct(int pid)
        {
            try
            {
                var prod=await _context.FindAsync<Product>(pid);
                var mapper=MapperConfig.InitializeAutomapper();
                var productDTO=mapper.Map<ProductDTO>(prod);
                return productDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductDTO>?> GetProducts(List<int> pids)
        {
            try
            {
                var products=await _context.products.Where(p=>pids.Contains(p.Id)).ToListAsync<Product>();
                var mapper = MapperConfig.InitializeAutomapper();
                List<ProductDTO> result = mapper.Map<List<ProductDTO>>(products);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int?> DeleteProduct(int pid)
        {
           // try
            //{
                var prod =await _context.FindAsync<Product>(pid);
            if (prod == null)
                return null;
                _context.products.Remove(prod);
                await _context.SaveChangesAsync();
                return prod.Id;

           // }
            
        }
        public async Task<int?> DeleteProducts(List<int> pids)
        {
            try
            {
                var prods = await _context.products.Where(p => pids.Contains(p.Id)).ToListAsync<Product>();
                if(prods==null) return null;
                _context.products.RemoveRange(prods);
                return prods.Count;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        //public async Task<bool> UpdateProduct(int pid)
        //{
        //    var prod = await _context.FindAsync<Product>(pid);
        //    if (prod == null) return false;

        //}

    }
}
