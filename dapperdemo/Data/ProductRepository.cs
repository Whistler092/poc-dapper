using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dapperdemo.Data
{

    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection dbConnection;

        public ProductRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }

        public async Task<Product> Add(Product product)
        {
            var id = await dbConnection.InsertAsync(product);

            product.Id = id;
            return product;

            //var sql = "INSERT INTO Products (Name, Category, Price) VALUES (@Name, @Category, @Price);"+
            //        "SELECT CAST(SCOPE_IDENTITY() AS INT)";

            //var queryResult = await dbConnection.QueryAsync<int>(sql, product);

            //product.Id = queryResult.FirstOrDefault();
            //return product;
        }

        public async Task Delete(int id)
        {
            //await dbConnection
            //            .ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
            await dbConnection.DeleteAsync(new Product { Id = id });
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await dbConnection.GetAllAsync<Product>();

            return products.ToList();

            //var products = await dbConnection
            //                .QueryAsync<Product>("SELECT * FROM Products");

            //return products.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await dbConnection.GetAsync<Product>(id);

            return product;

            //var product = await dbConnection
            //                .QueryFirstAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });

            //return product;
        }
    }
}
