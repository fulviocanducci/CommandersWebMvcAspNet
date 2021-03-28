using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commanders.Models.Mappings
{
    public class TodoMapping : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Done)
                .HasDefaultValue(false);
            builder.HasIndex(x => x.Description);
            builder.HasIndex(x => x.Done);                
        }
    }
}