using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Commerce.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public bool EnableManualDispose { get; set; }
        public UnitOfWork(IMapper mapper)
        {
            Mapper = mapper;
        }
        public CommerceContext Context { get; }

        public IMapper Mapper { get; }

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(Context, Mapper);

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void RollBack()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            if (!EnableManualDispose)
                Context?.Dispose();
        }

        public void ManualDispose()
        {
            EnableManualDispose = false;
            Context?.Dispose();
        }
    }
}
