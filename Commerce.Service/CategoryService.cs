using AutoMapper;
using Commerce.Repository.Entities;
using Commerce.Repository.Models;
using Commerce.Repository.Repositories;
using Commerce.Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Service
{
    public interface ICategoryService
    {
        Task<int> AddCategory(CategoryModel category);
        Task<int> Update(CategoryModel category);
        Task DeleteById(int id);
        Task DeleteByIds(List<int> ids);
        Task<List<CategoryModel>> GetAll(int page, int pageSize);
        Task<CategoryModel> GetById(int id);
        Task<List<CategoryModel>> GetByIds(List<int> ids, int page, int pageSize);
    }
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public Task<int> AddCategory(CategoryModel categoryModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var category = _mapper.Map<CategoryModel, Category>(categoryModel);
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Commit();
                return Task.FromResult(category.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteById(int id)
        {
            var category = await _unitOfWork.CategoryRepository.FindAsync(id);
            try
            {
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task DeleteByIds( List<int> ids)
        {
            var categories = await _categoryRepository.GetAllByIds(ids);
            try
            {
                _unitOfWork.CategoryRepository.DeleteRange(categories);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<List<CategoryModel>> GetAll(int page, int pageSize)
        {
            return await _categoryRepository.GetAll(page, pageSize);
        }

        public async Task<CategoryModel> GetById(int id)
        {
            return  _mapper.Map<Category,CategoryModel>(await _unitOfWork.CategoryRepository.FindAsync(id));
        }

        public async Task<List<CategoryModel>> GetByIds(List<int> ids, int page, int pageSize)
        {
            return await _categoryRepository.GetAll(page, pageSize, ids);
        }

        public Task<int> Update(CategoryModel categoryModel)
        {
            var category = _mapper.Map<CategoryModel, Category>(categoryModel);
            try 
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Commit();

                return Task.FromResult(category.Id);
            }
            catch
            {
                _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
