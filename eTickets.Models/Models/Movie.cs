using eTickets.Models.Models;
using eTickets.Models.Models.Base;
using eTickets.Models.Models.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public MovieCategory Category { get; set; }

        //relations
        public List<Actor_Movie>? Actor_Movies { get; set; }

        //CINEMA
        [ForeignKey("CinemaId")]
        [Required]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        //PRODUCER 

        [ForeignKey("ProducerId")]
        [Required]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
