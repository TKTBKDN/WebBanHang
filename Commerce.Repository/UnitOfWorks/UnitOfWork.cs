using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Commerce.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public bool EnableManualDispose { get; set; }
        public CommerceContext Context { get; }

        private readonly IConfiguration _configuration;
        public UnitOfWork(CommerceContext context, IMapper mapper, IConfiguration configuration)
        {
            Context = context;
            Mapper = mapper;
            _configuration = configuration;
        }


        public IMapper Mapper { get; }

        private IProductRepository _productRepository;

        private IUserRepository _userRepository;

        private ICategoryRepository _categoryRepository;

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(Context, Mapper, _configuration);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(Context, Mapper);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(Context, Mapper, _configuration);

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
