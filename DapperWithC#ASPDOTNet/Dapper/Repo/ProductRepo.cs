using DapperProject.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DapperProject.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly string? _connectionString;
        public ProductRepo(IConfiguration configuration)
        {
           this._connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public List<Product> GetAll()
        {
            var sql = "Select * From Products";

            var connection = new SqlConnection(_connectionString);

            var products = connection.Query<Product>(sql).ToList();
            
            return products;
        }

        public Product GetById(int id)
        {
            var sql = "Select * From Products where ProductID = @ProductID";
            var connection = new SqlConnection(_connectionString);
            var product = connection.QuerySingle<Product>(sql, new { ProductID = id });

            return product;
        }
    }
}
