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

            builder.OwnsOne(x => x.Name)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Name)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50);

            builder.OwnsOne(c => c.Email)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.Address)
                .HasColumnName("EmailAddress")
                .HasMaxLength(100);

            builder.OwnsOne(p => p.CellPhone)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.Number)
                .HasColumnName("CellPhoneNumber")
                .HasMaxLength(11);

            builder.OwnsOne(p => p.CellPhone)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.IsWhatsApp)
                .HasColumnName("CellPhoneIsWhatsApp");

            builder.OwnsOne(p => p.HomePhone)
                .Ignore(c => c.Notifications)
                .Ignore(c => c.Valid)
                .Ignore(c => c.Invalid)
                .Property(c => c.Number)
                .HasColumnName("HomePhoneNumber")
                .HasMaxLength(100);

            var navigation = builder.Metadata.FindNavigation(nameof(Prospect.Intentions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Property);
            builder.HasMany(g => g.Intentions).WithOne().OnDelete(DeleteBehavior.Cascade).HasForeignKey(c => c.ProspectId);
        }
    }
}
