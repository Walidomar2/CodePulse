namespace CodePulse.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateAsync(Category category);
    }
}
