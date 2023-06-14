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
            var mapper = MapperConfig.InitializeAutomapper();
            var prod=mapper.Map<Product>(product);
            var result=await _context.AddAsync<Product>(prod);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
