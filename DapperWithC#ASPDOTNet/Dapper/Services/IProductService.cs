using DapperProject.Models;
namespace DapperProject.Services
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);
    }
}
