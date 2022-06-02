<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
=======
﻿using Commerce.Repository.Entities;
using Commerce.Repository.UnitOfWorks;
using System.Collections.Generic;
>>>>>>> main
using System.Threading.Tasks;

namespace Commerce.Service
{
<<<<<<< HEAD
    class ProductService
    {
=======
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsQuery();
        Task Add(Product product);
    }

    public class ProductService : IProductService
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

        public async Task<List<Product>> GetProductsQuery()
        {
            return await _unitOfWork.ProductRepository.GetAllByQuery();
        }
>>>>>>> main
    }
}
