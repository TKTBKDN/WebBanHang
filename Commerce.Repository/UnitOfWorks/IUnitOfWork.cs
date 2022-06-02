using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using Commerce.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.UnitOfWorks
{
    public interface IUnitOfWork
    {
        CommerceContext Context { get; }
        void BeginTransaction();
        void RollBack();
        void Commit();
        void SaveChanges();
        IMapper Mapper { get; }

        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
