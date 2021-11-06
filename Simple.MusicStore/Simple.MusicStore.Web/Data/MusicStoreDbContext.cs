using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Data
{
    public class MusicStoreDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public MusicStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        private string LocalDb = "Server=(localdb)\\MSSQLLocalDB;Database=ChinookDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(LocalDb)
                    .UseLazyLoadingProxies()
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, 
                            LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }

            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(m =>
            {
                m.ToTable("Artist");
                m.Property(a => a.Id).HasColumnName("ArtistId");
            });

            modelBuilder.Entity<Album>(m =>
            {
                m.ToTable("Album");
                m.Property(a => a.Id).HasColumnName("AlbumId");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
