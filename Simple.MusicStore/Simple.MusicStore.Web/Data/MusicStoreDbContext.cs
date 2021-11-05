using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Data
{
    public class MusicStoreDbContext : DbContext
    {
        private const string LocalDb = "Server=(localdb)\\MSSQLLocalDB;Database=ChinookDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public DbSet<Artist> Artists { get; set; }
        
        public MusicStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(LocalDb)
                    .UseLazyLoadingProxies()
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(m =>
            {
                m.ToTable("Artist").HasKey(c => c.Id);
                m.Property(c => c.Id).HasColumnName("ArtistId");
            });
        }
    }
}