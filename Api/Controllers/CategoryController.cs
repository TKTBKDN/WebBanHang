using Commerce.Repository.Models;
using Commerce.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("getAll/{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var categories = await _categoryService.GetAll(page, pageSize);
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CategoryModel categoryModel)
        {
            var categoryId = await _categoryService.AddCategory(categoryModel);
            // need use signR but do after
            return Ok(categoryId);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryModel categoryModel)
        {
            var categoryId = await _categoryService.Update(categoryModel);
            return Ok(categoryId);
        }
    }
}
