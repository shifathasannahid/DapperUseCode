using DapperProject.Models;

namespace DapperProject.Repo
{
    public interface IProductRepo
    {
        List<Product> GetAll();

        Product GetById(int id);

        List<Product> GetByCategoryId(int categoryId);

        void Create(Product product);

        void Edit(Product product);

        void Delete(int  id);
    }
}
