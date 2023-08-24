using Microsoft.EntityFrameworkCore;
using MyPhotosEntity.Concrete;

namespace MyPhotosDataAccess.Concrete.EntityFramework.Context
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=TestDb;Integrated Security=True");
        }

        public DbSet<Photo>? Photos { get; set; }
    }
}
