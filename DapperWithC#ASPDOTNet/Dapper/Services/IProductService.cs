using DapperProject.Models;
namespace DapperProject.Services
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        List<Product> GetByCategoryId(int categoryId);
    
       void Create(Product product);

        void Edit(Product product);

        void Delete(int  id);
    }
}
