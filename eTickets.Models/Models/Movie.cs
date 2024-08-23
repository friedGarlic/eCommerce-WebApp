using eTickets.Models.Models;
using eTickets.Models.Models.Enumerables;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieCategory Category { get; set; }

        //relations
        public List<Actor_Movie> Actor_Movies { get; set; }

        //CINEMA
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        //PRODUCER 

        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
