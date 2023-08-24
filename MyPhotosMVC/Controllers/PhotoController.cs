using Microsoft.AspNetCore.Mvc;
using MyPhotosBusiness.Abstract;
using MyPhotosEntity.Dto;
using MyPhotosMVC.Models;

namespace MyPhotosMVC.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photo;

        public PhotoController(IPhotoService photo)
        {
            _photo = photo;
        }

        public IActionResult Index()
        {
            var photos = _photo.GetList();
            return View(photos);
        }

        [HttpGet("Photo")]
        public IActionResult Photo()
        {
            var photos = _photo.GetList();
            return View(photos);
        }

        public async Task<IActionResult> AddPhoto(PhotoAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var memoryStream = new MemoryStream();
                await model.ImageFile.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();

                var modal = new AddPhotoRequestDto
                {
                    Title = model.Title,
                    Tags = model.Tags,
                    ImageData = imageData
                };

                _photo.Add(modal);

                return RedirectToAction(nameof(Photo));
            }

            return View(model);
        }

        public IActionResult PhotoDetail(int id)
        {
            var photo = _photo.GetPhoto(id);
            if (photo == null)
            {
                return NotFound();
            }

            var viewModel = new PhotoDetailViewModel
            {
                Title = photo.Title,
                Tags = photo.Tags,
                ImageData = photo.ImageData,
                Id = photo.Id
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeletePhoto(int id)
        {
            _photo.Update(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
