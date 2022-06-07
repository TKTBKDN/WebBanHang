using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using Commerce.Repository.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllByIds(List<int> ids);
        Task<List<CategoryModel>> GetAll(int page = 1, int pageSize = 20, List<int> ids = null);
    }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        public CategoryRepository(CommerceContext dbcontext, IMapper mapper, IConfiguration configuration) : base(dbcontext, mapper)
        {
            _configuration = configuration;
        }

        public async Task<List<CategoryModel>> GetAll(int page = 0, int pageSize = 20, List<int> ids = null)
        {

            var conStr = _configuration.GetConnectionString("DefautlConnection");
            using (var connection = new SqlConnection(conStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@page", page * pageSize, System.Data.DbType.Int32);
                parameters.Add("@pageSize", pageSize, System.Data.DbType.Int32);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * From Categories ");
                sb.Append("WHERE IsDeleted = 0 ");
                sb.Append("ORDER BY Name ");
                sb.Append("OFFSET @page ROWS FETCH NEXT @pageSize ROWS ONLY");
                string query = sb.ToString();

                var result = await connection.QueryAsync<CategoryModel>(query, parameters);
                if(ids != null)
                {
                    return result.Where(x => ids.Contains(x.Id)).ToList();
                }
                return result.ToList();
            }
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllByIds(List<int> ids)
        {
            return await DbContext.Categories.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
