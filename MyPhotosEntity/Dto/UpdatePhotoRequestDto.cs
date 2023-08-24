namespace MyPhotosEntity.Dto
{
    public class UpdatePhotoRequestDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Tags { get; set; }
        public byte[]? ImageData { get; set; }
        public int Status { get; set; }
    }
}
