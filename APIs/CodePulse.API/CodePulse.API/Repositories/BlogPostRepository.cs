


using Microsoft.EntityFrameworkCore;

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
            return await _context.BlogPosts.Include(x => x.Categories).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(Guid id)
        {
            return await _context.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> UpdateAsync(Guid id, BlogPost blogPost)
        {
            var blogPostDB = await _context.BlogPosts.Include(c => c.Categories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if(blogPostDB is null)
            {
                return null;
            }

            blogPostDB.ShortDescription = blogPost.ShortDescription;
            blogPostDB.Author = blogPost.Author;
            blogPostDB.Content = blogPost.Content;
            blogPostDB.IsVisible = blogPost.IsVisible;
            blogPostDB.Title = blogPost.Title;
            blogPostDB.FeaturedImageUrl = blogPost.FeaturedImageUrl;
            blogPostDB.UrlHandle = blogPost.UrlHandle;  
            blogPostDB.PublishedDate = blogPost.PublishedDate;
            blogPost.Categories = blogPost.Categories;  

            await _context.SaveChangesAsync();
            return blogPostDB;
        }
    }
}
