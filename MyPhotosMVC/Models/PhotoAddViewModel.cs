using System.ComponentModel.DataAnnotations;

namespace MyPhotosMVC.Models
{
    public class PhotoAddViewModel
    {
        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Tags { get; set; }
    }

}
