using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}
