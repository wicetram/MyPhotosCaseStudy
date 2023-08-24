using MyPhotosCore.DataAccess;
using MyPhotosEntity.Concrete;

namespace MyPhotosDataAccess.Abstract
{
    public interface IPhotoDal : IEntityRepository<Photo>
    {
    }
}
