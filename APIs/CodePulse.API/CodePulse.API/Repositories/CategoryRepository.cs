using CodePulse.API.Interfaces;

namespace CodePulse.API.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category is null)
            {
                return null;
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var categoryDb = await _context.Categories.FindAsync(id);

            if (categoryDb is null)
            {
                return null;
            }

            _context.Categories.Remove(categoryDb);
            await _context.SaveChangesAsync();

            return categoryDb;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
          
        }

        public async Task<Category?> UpdateAsync(Guid id, Category category)
        {
            var categoryDb = await _context.Categories.FindAsync(id);
            if(categoryDb is null)
            {
                return null;
            }

            category.Id = id;
            categoryDb.Name = category.Name;
            categoryDb.UrlHandle = category.UrlHandle;

            await _context.SaveChangesAsync();

            return category;
        }
    }
}
