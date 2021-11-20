using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Tests
{
    [TestClass]
    public class ImageServiceTests
    {
        [TestMethod]
        public void Can_insert_image()
        {
            var sut = CreateSUT();
            var fileBytes = File.ReadAllBytes(@"D:\_dvlp\ComIT\ComITReginaSept13\Simple.MusicStore\Simple.MusicStore.Web\wwwroot\img\album1.jpg");
            var base64Content = Convert.ToBase64String(fileBytes);
            sut.Add(new AppFile() { FileContents = base64Content, ContentType = "image/jpeg", Path = "/albums/album1.jpg" });
        }


        [TestMethod]
        public void Can_get_image()
        {
            var sut = CreateSUT();
            var image = sut.Find("/albums/album1.jpg");
            Assert.IsNotNull(image);
            Assert.AreEqual("/albums/album1.jpg".ToLowerInvariant(), image.Path.ToLowerInvariant());
        }

        [TestMethod]
        public void Add_images_to_database()
        {
            var sut = CreateSUT();

            var imagesPath = @"D:\_dvlp\ComIT\ComITReginaSept13\Simple.MusicStore\Simple.MusicStore.Web\wwwroot\img\";

            var files =  Directory.EnumerateFiles(imagesPath);

            foreach (var filePath in files)
            {
                if (filePath.EndsWith(".jpg") && !filePath.EndsWith("album1.jpg"))
                {
                    var fileBytes = File.ReadAllBytes(filePath);
                    var base64Content = Convert.ToBase64String(fileBytes);
                    var fileName = Path.GetFileName(filePath);
                    sut.Add(new AppFile() { FileContents = base64Content, ContentType = "image/jpeg", Path = $"/albums/{fileName}" });
                }
            }
        }

        private ImageService CreateSUT()
        {
            return new ImageService(GetDbContext());
        }

        private MusicStoreDbContext GetDbContext()
        {
            return new MusicStoreDbContext();
        }
    }
}