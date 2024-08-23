using eTickets.Models.Models;

namespace eTickets.Models
{
    public class Actor
    {
        public int Id {  get; set; }

        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio {  get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
