using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProducts();
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CommerceContext dbcontext, IMapper mapper) : base(dbcontext,mapper)
        {

        }

        public async Task<List<Product>> GetProducts()
        {
            return await DbContext.Products.ToListAsync();
        }
    }
}
