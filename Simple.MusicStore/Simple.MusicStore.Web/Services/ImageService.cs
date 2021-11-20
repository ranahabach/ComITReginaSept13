using System.Linq;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Simple.MusicStore.Web.Data;

namespace Simple.MusicStore.Web.Services
{
    public class ImageService
    {
        private readonly MusicStoreDbContext _dbContext;

        public ImageService(MusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppFile Find(string path)
        {
            return _dbContext
                .AppFile
                .FirstOrDefault(f => f.Path == path);
        }

        public void Add(AppFile appFile)
        {
            _dbContext.AppFile.Add(appFile);

            _dbContext.SaveChanges();
        }
    }
}