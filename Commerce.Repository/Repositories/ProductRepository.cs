using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetAllByQuery();
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductRepository(CommerceContext dbcontext, IMapper mapper, IConfiguration configuration) : base(dbcontext,mapper)
        {
            _configuration = configuration;
        }

        public async Task<List<Product>> GetAllByQuery()
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("@UserId", userId);
            var conStr = _configuration.GetConnectionString("DefautlConnection");
            using (var connection = new SqlConnection(conStr))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"SELECT * FROM Products");
                var response = await connection.QueryAsync<Product>(builder.ToString());
                return response.AsList();

            } 
            return null;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await DbContext.Products.ToListAsync();
        }
    }
}
