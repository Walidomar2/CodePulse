namespace CodePulse.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(); 
        Task<Category?> GetByIdAsync(Guid id);    
        Task<Category?> UpdateAsync(Guid id,Category category);
        Task<Category?> DeleteAsync(Guid id);
    }
}
