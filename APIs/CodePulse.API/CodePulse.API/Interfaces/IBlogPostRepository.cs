namespace CodePulse.API.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost?> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();  
        Task<BlogPost?> GetByIdAsync(Guid id);
        Task<BlogPost?> UpdateAsync(Guid id, BlogPost blogPost);
    }
}
