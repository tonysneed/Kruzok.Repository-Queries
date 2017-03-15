using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Models;

namespace HelloWebApi.Repositories {

    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
        Task Delete(int id);
    }
}