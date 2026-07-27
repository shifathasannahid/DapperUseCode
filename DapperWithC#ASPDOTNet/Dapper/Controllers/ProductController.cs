using Microsoft.AspNetCore.Mvc;
using DapperProject.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using DapperProject.Services;

namespace DapperProject.Controllers
{
    public class ProductController : Controller
    {
        #region First 2 Video er code

        //private readonly string? _connectionString;
        //public ProductController(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");

        //}

        //Dapper use kora chara code

        //public IActionResult Index()
        //{
        //    var sql = "Select * From Products";
        //    var products = new List<Product>();
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        using (var cmd = new SqlCommand(sql, connection))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var product = new Product
        //                    {
        //                        ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),

        //                        ProductName = reader.GetString(reader.GetOrdinal("ProductName")),

        //                        SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),

        //                        CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),

        //                        UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),

        //                        UnitsInStock = reader.GetInt32(reader.GetOrdinal("UnitsInStock")),

        //                        UnitsOnOrder = reader.GetInt32(reader.GetOrdinal("UnitsOnOrder")),

        //                        Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"))
        //                    };
        //                    products.Add(product);
        //                }

        //            }

        //        }
        //    }
        //    return View(products);
        //}






        //Dapper use kora code
        //public async Task<IActionResult> Index()
        //{
        //    var sql = "Select * From Products";

        //    var connection = new SqlConnection(_connectionString);

        //    var products = connection.Query<Product>(sql).ToList();

        //    //Dapper er ExecuteScalar Method
        //    //var countSql = "Select Count(*) From Products";
        //    //var count = connection.ExecuteScalar<int>(countSql);
        //    //ViewBag.Count = count;
        //    //return View(products);

        //    //Dapper er ExecuteScalarAsynsc Method
        //    var countSql = "Select Count(*) From Products";
        //    int count = await connection.ExecuteScalarAsync<int>(countSql);
        //    ViewBag.Count = count;
        //    return View(products);
        //}
        #endregion First 2 Video er code

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var product = _productService.GetAll();
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }


    }
}
