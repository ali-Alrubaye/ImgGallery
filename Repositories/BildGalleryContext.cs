
using System.Data.Entity;
using Repositories.Models;
using static System.Data.Entity.Database;

namespace Repositories
{
    public class BildGalleryContext : DbContext
    {
        public BildGalleryContext() : base("BildGallerContext")
        {
            SetInitializer<BildGalleryContext>(new DropCreateDatabaseIfModelChanges<BildGalleryContext>());
        }
        
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}
    }
}
