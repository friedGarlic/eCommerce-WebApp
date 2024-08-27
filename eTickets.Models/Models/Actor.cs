using eTickets.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        public int Id {  get; set; }

        [Display(Name = "Profilc Picture Url")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Actor Biography")]
        public string Bio {  get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
