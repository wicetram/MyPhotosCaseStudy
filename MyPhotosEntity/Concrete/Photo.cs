namespace MyPhotosEntity.Concrete
{
    public class Photo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Tags { get; set; }
        public byte[]? ImageData { get; set; }
        public DateTime? Date { get; set; }
        public string? Time { get; set; }
        public int Status { get; set; }
    }
}
