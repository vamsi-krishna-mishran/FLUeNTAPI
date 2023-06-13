using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IProductRepository
    {
        public Task<int> AddProduct(ProductDTO product);
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
            var result=await _context.AddAsync<Product>(product);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
