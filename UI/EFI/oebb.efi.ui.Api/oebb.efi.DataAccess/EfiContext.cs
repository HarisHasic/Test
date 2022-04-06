using Microsoft.EntityFrameworkCore;
using oebb.efi.DataAccess.Models;

namespace oebb.efi.DataAccess
{
    public class EfiContext : DbContext
    {
        public  DbSet<Station>? Stations { get; set; }

        public EfiContext() : base()
        {

        }

        public EfiContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Find classes that implements IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(EfiContext).Assembly);
        }
    }
}