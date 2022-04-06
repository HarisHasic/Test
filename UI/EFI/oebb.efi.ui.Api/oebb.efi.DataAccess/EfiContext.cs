using Microsoft.EntityFrameworkCore;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.DataAccess
{
    public class EfiContext : DbContext
    {
        public virtual DbSet<StationEntity> Stations => Set<StationEntity>();

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