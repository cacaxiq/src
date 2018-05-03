using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.ExternalData.Configuration
{
    public class ProspectConfig : IEntityTypeConfiguration<Prospect>
    {
        public void Configure(EntityTypeBuilder<Prospect> builder)
        {
            builder.ToTable(nameof(Prospect));

            builder.Ignore(c => c.Notifications);
            builder.Ignore(c => c.Valid);
            builder.Ignore(c => c.Invalid);

            builder.Property(c => c.Id);
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Name)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid);

            builder.OwnsOne(c => c.Email)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid);

            builder.OwnsOne(p => p.CellPhone)
            .Ignore(c => c.Notifications)
            .Ignore(c => c.Valid)
            .Ignore(c => c.Invalid);

            builder.OwnsOne(p => p.HomePhone)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid);

            var navigation = builder.Metadata.FindNavigation(nameof(Prospect.Intentions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Property);
            builder.HasMany(g => g.Intentions).WithOne(s => s.Prospect).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
