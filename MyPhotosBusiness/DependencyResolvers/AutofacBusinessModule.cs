using Autofac;
using MyPhotosBusiness.Abstract;
using MyPhotosBusiness.Concrete;
using MyPhotosDataAccess.Concrete.EntityFramework;

namespace MyPhotosBusiness.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhotoManager>().As<IPhotoService>();
            builder.RegisterType<EfPhotoDal>();
        }
    }
}
