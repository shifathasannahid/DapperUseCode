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

        public List<Product> GetByCategoryId(int categoryId)
        {
            var sql = "Select * from Products where  CategoryID = @categoryId";
            var connection = new SqlConnection(_connectionString);
            var product = connection.Query<Product>(sql, new { categoryId = categoryId }).ToList();
            return product;
        }

        public Product GetById(int id)
        {
            var sql = "Select * From Products where ProductID = @ProductID";
            var connection = new SqlConnection(_connectionString);
            var product = connection.QuerySingle<Product>(sql, new { ProductID = id });

            return product;
        }

        //CRUD Operation with Dapper
        public void Create(Product product)
        {
            var sql = @"Insert Into Products
               (ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,UnitsOnOrder,Discontinued,DiscontinuedDate) 
               Values(@ProductName,@SupplierID,@CategoryID,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@Discontinued,@DiscontinuedDate)";
            var connection = new SqlConnection(_connectionString);

            connection.Execute(sql, new
            {
                product.ProductName,
                product.SupplierID,
                product.CategoryID,
                product.UnitPrice,
                product.UnitsInStock,
                product.UnitsOnOrder,
                product.Discontinued,
                product.DiscontinuedDate,

            });

        }


        public void Edit(Product product)
        {
            var sql = @"Update Products
                Set ProductName=@ProductName
                ,SupplierID = @SupplierID
                ,CategoryID = @CategoryID
                ,UnitPrice  = @UnitPrice
                ,UnitsInStock = @UnitsInStock
                ,UnitsOnOrder = @UnitsOnOrder
                ,Discontinued = @Discontinued
                ,DiscontinuedDate = @DiscontinuedDate
                Where ProductID = @ProductID";
            var connection = new SqlConnection(_connectionString);

            connection.Execute(sql, new
            {
                ProductName =  product.ProductName,
                SupplierID  =  product.SupplierID,
                CategoryID  =  product.CategoryID,
                UnitPrice   =  product.UnitPrice,
                UnitsInStock=  product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                Discontinued = product.Discontinued,
                DiscontinuedDate= product.DiscontinuedDate,
                ProductID = product.ProductID

            });
        }

        public void Delete(int id)
        {
            var sql = @"Delete From Products Where ProductID = @id";

            var connection = new SqlConnection(_connectionString);
            connection.Execute(sql, new { id = id });
        }

    }
}
