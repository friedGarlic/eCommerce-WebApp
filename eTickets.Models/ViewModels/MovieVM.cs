using eTickets.Models.Models.Enumerables;
using eTickets.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.ViewModels
{
    public class MovieVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please select a Category")]
        public MovieCategory Category { get; set; }

        //relations
        [Required(ErrorMessage = "Please select a CinemaId")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Please select a ProducerId")]
        public int ProducerId { get; set; }

        public List<int> ActorIds { get; set; }

    }
}
