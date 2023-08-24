using MyPhotosCore.DataAccess.EntityFramework;
using MyPhotosDataAccess.Abstract;
using MyPhotosDataAccess.Concrete.EntityFramework.Context;
using MyPhotosEntity.Concrete;

namespace MyPhotosDataAccess.Concrete.EntityFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, SimpleContextDb>, IPhotoDal
    {
    }
}
