﻿

namespace CodePulse.API.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BlogPost?> CreateAsync(BlogPost blogPost)
        {
            if(blogPost is null)
            {
                return null;    
            }

            await _context.BlogPosts.AddAsync(blogPost);    
            await _context.SaveChangesAsync();

            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }
    }
}
