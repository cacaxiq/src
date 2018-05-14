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
            builder.Property(c => c.AccessKey).HasColumnType("decimal(10, 2)");

            builder.OwnsOne(c => c.Name)
             .Ignore(c => c.Notifications)
             .Ignore(c => c.Valid)
             .Ignore(c => c.Invalid);
        }
    }
}
