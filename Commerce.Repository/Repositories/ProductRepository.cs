using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CommerceContext dbcontext, IMapper mapper) : base(dbcontext,mapper)
        {

        }
    }
}
