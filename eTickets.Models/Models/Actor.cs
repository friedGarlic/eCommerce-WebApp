using eTickets.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        public int Id {  get; set; }

        [Display(Name = "Profilc Picture Url")]
        [Required(ErrorMessage = "Picture is required")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Biography or description is required")]
        [Display(Name = "Actor Biography")]
        public string Bio {  get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
