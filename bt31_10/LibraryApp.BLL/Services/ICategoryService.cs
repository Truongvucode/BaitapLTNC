using LibraryApp.BLL.DTOs;

namespace LibraryApp.BLL.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
    }
}
