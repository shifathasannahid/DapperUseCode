using DapperProject.Models;
using DapperProject.Repo;

namespace DapperProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo) 
        {
            _productRepo = productRepo;
        }
        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }
    }
}
