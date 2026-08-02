using DapperProject.Models;
using DapperProject.Repo;
using Microsoft.Data.SqlClient;

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

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productRepo.GetByCategoryId(categoryId);
        }

        public Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }

        //CRUD operation with Dapper

        public void Create(Product product)
        {
            _productRepo.Create(product);
        }

        public void Delete(int id)
        {
            _productRepo.Delete(id);
        }

        public void Edit(Product product)
        {
           _productRepo.Edit(product);
        }
    }
}
