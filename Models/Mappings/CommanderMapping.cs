using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commanders.Models.Mappings
{
    public class CommanderMapping : IEntityTypeConfiguration<Commander>
    {
        public void Configure(EntityTypeBuilder<Commander> builder)
        {
            builder.ToTable("Commanders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Name);
        }
    }
}