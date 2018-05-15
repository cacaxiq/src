using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.ExternalData.Configuration
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Ignore(c => c.Notifications);
            builder.Ignore(c => c.Valid);
            builder.Ignore(c => c.Invalid);

            builder.Property(c => c.Id);
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AccessKey).IsRequired().HasColumnType("varchar(50)");
            builder.Property(c => c.UserID).IsRequired().HasColumnType("varchar(20)");

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
        }
    }
}
