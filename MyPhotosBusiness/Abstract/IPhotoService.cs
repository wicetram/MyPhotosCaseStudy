using MyPhotosEntity.Concrete;
using MyPhotosEntity.Dto;

namespace MyPhotosBusiness.Abstract
{
    public interface IPhotoService
    {
        int Add(AddPhotoRequestDto addPhotoRequestDto);
        int Update(int id);
        List<Photo>? GetList();
        Photo? GetPhoto(int id);
    }
}
