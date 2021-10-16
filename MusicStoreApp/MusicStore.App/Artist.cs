
namespace MusicStore.App
{
    public class Artist
    {
        private string _firstName;
        private string _lastName;

        public string FirstName { get; }
        public string LastName { get; }

        public Artist(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
