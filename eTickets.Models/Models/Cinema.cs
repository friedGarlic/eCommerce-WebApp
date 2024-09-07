using eTickets.Models.Models.Base;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get;}

        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
