using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.App;
using MusicStore.Common;
using MusicStore.Db;

namespace MusicStore.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AlbumService service = new AlbumService();
            MusicStoreDbContext db = new MusicStoreDbContext();
            Logger logger = new Logger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
