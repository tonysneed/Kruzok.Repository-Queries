using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWebApi.Contexts;
using HelloWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWebApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsDbContext _context;
        public ProductsRepository(ProductsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductName).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> Insert(Product product)
        {
            // Mark entity as Added
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            // Mark entity as Modified
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task Delete(int id)
        {
            // Mark entity as Deleted
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}