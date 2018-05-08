using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.ExternalData.Configuration
{
    public class IntentionConfig : IEntityTypeConfiguration<Intention>
    {
        public void Configure(EntityTypeBuilder<Intention> builder)
        {
            builder.ToTable(nameof(Intention));

            builder.Ignore(c => c.Notifications);
            builder.Ignore(c => c.Valid);
            builder.Ignore(c => c.Invalid);

            builder.Property(c => c.Id);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Rent).HasColumnType("decimal(10, 2)");
            builder.Property(c => c.Bedroom);
            builder.Property(c => c.PropertyType);
            builder.Property(c => c.PropertySituation);

            builder.Property(p => p.LowestPrice)
                 .HasColumnName("LowestPrice")
                 .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.MaximumPrice)
                   .HasColumnName("MaximumPrice")
                   .HasColumnType("decimal(10, 2)"); ;

            builder.Property(p => p.State)
                 .HasColumnName("State");

            builder.Property(p => p.City)
                 .HasColumnName("City")
                 .HasMaxLength(50);

            builder.Property(p => p.Neighborhood)
                 .HasColumnName("Neighborhood")
                 .HasMaxLength(50);
        }
    }
}
