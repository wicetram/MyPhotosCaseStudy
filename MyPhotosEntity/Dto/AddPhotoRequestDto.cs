namespace MyPhotosEntity.Dto
{
    public class AddPhotoRequestDto
    {
        public string? Title { get; set; }
        public string? Tags { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
