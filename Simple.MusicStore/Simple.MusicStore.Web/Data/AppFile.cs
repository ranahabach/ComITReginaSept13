using System.ComponentModel.DataAnnotations;
using Castle.Components.DictionaryAdapter;

namespace Simple.MusicStore.Web.Data
{
    public class AppFile   
    {
        public int FileId { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string FileContents { get; set; }
    }

    /*
     public partial class AppFile
    {
        public int FileId { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string FileContents { get; set; }
    }

     */
}