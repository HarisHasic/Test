using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace oebb.efi.DataAccess.Models.Configuration
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable("Station");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Shortcut).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SearchTerm).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Station { Id = 1, Shortcut = "W", Description = "Wien", SearchTerm = "Wien" },
                new Station { Id = 2, Shortcut = "S", Description = "Salzburg", SearchTerm = "Salzburg" },
                new Station { Id = 3, Shortcut = "L", Description = "Linz", SearchTerm = "Linz" }
            );
        }
    }
}
