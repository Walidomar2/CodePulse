namespace CodePulse.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();     
    }
}
