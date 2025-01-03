﻿namespace CodePulse.API.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost?> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();  
    }
}
