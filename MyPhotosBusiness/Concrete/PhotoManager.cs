using MyPhotosBusiness.Abstract;
using MyPhotosDataAccess.Concrete.EntityFramework;
using MyPhotosEntity.Concrete;
using MyPhotosEntity.Dto;

namespace MyPhotosBusiness.Concrete
{
    public class PhotoManager : IPhotoService
    {
        private readonly EfPhotoDal _photoDal;

        public PhotoManager(EfPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }

        public int Add(AddPhotoRequestDto addPhotoRequestDto)
        {
            try
            {
                var photo = CreatePhoto(addPhotoRequestDto);
                return _photoDal.Add(photo);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(int id)
        {
            try
            {
                var photo = UpdatePhoto(id);
                return _photoDal.Delete(photo);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private Photo UpdatePhoto(int id)
        {
            var photo = new Photo();
            try
            {
                var retrievedPhoto = GetPhoto(id);
                if (retrievedPhoto != null)
                {
                    photo.Id = retrievedPhoto.Id;
                    photo.Title = retrievedPhoto.Title;
                    photo.Tags = retrievedPhoto.Tags;
                    photo.ImageData = retrievedPhoto.ImageData;
                    if (DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd"), out DateTime parsedDate))
                    {
                        photo.Date = parsedDate;
                    }
                    photo.Time = DateTime.Now.ToString("HH:mm:ss");
                    photo.Status = 1;
                }
            }
            catch (Exception)
            {
            }
            return photo;
        }

        private static Photo CreatePhoto(AddPhotoRequestDto addPhotoRequestDto)
        {
            var photo = new Photo();
            try
            {
                if (addPhotoRequestDto != null)
                {
                    if (!string.IsNullOrEmpty(addPhotoRequestDto.Title) && !string.IsNullOrEmpty(addPhotoRequestDto.Tags))
                    {
                        var id = new Random().Next(1, 999999);

                        photo.Id = id;
                        photo.Title = addPhotoRequestDto.Title;
                        photo.Tags = addPhotoRequestDto.Tags;
                        if (DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd"), out DateTime parsedDate))
                        {
                            photo.Date = parsedDate;
                        }
                        photo.Time = DateTime.Now.ToString("HH:mm:ss");
                        photo.ImageData = addPhotoRequestDto.ImageData;
                        photo.Status = 1;
                    }
                }
            }
            catch (Exception)
            {
            }
            return photo;
        }

        public List<Photo>? GetList()
        {
            try
            {
                return _photoDal.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Photo? GetPhoto(int id)
        {
            try
            {
                return _photoDal.Get(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
