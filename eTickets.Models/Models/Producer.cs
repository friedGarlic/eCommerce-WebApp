using eTickets.Models.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get;}

        [Required(ErrorMessage = "Profile Picture Url is Required")]
        [DisplayName("Profile Picture Url")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bio Description is Required")]
        [DisplayName("Biography")]
        public string Bio { get; set; }
    }
}
