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
            builder.Property(c => c.Rent).HasColumnType("decimal(5, 2)"); ;
            builder.OwnsOne(p => p.PriceRange)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid);

            builder.Property(c => c.Bedroom);
            builder.OwnsOne(p => p.Place)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid);

            builder.Property(c => c.PropertyType).IsRequired();
            builder.Property(c => c.PropertySituation).IsRequired();
        }
    }
}
