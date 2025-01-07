namespace CodePulse.API.Interfaces
{
    public interface IImageRepository
    {
        Task<BlogImage> UploadAsync(IFormFile file, BlogImage blogImage);
    }
}
