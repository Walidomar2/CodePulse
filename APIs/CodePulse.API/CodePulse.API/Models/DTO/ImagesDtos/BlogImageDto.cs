namespace CodePulse.API.Models.DTO.ImagesDtos
{
    public class BlogImageDto
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
