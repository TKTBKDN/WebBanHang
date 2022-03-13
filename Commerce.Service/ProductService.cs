using Commerce.Repository.Entities;
using Commerce.Repository.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task Add(Product product);
    }

    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Product product)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _unitOfWork.ProductRepository.Add(product);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _unitOfWork.ProductRepository.GetAsync();
        }
    }
}
