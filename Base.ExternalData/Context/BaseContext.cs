using Base.ExternalData.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Base.ExternalData.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IntentionConfig());
            modelBuilder.ApplyConfiguration(new ProspectConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
  