using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWebApi.Contexts;
using HelloWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWebApi.Repositories{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProductsDbContext _context;
        public CategoriesRepository(ProductsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        }
    }
}