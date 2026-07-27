using DapperProject.Models;

namespace DapperProject.Repo
{
    public interface IProductRepo
    {
        List<Product> GetAll();

        Product GetById(int id);
    }
}
