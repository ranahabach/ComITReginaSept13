using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MusicStore.Db
{
    public class MusicStoreDbContext : DbContext
    {

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Image> Images { get; set; }
        
        public MusicStoreDbContext()
        {
        }

        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options)
        {
        }

        private string LocalDb = "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDemo;Trusted_Connection=True;MultipleActiveResultSets=True";

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
            else
            {
                optionsBuilder
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
        }
    }
}
