using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.DataAccess.Models.Configuration
{
    public class StationEntityConfiguration : IEntityTypeConfiguration<StationEntity>
    {
        public void Configure(EntityTypeBuilder<StationEntity> builder)
        {
            builder.ToTable("Station");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Shortcut).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SearchTerm).IsRequired().HasMaxLength(50);

            builder.HasData(
                new StationEntity { Id = 1, Shortcut = "W", Description = "Wien", SearchTerm = "Wien" },
                new StationEntity { Id = 2, Shortcut = "S", Description = "Salzburg", SearchTerm = "Salzburg" },
                new StationEntity { Id = 3, Shortcut = "L", Description = "Linz", SearchTerm = "Linz" }
            );
        }
    }
}
