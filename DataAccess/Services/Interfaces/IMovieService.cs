using eTickets.DataAccess.Repositories.Interfaces;
using eTickets.Models;
using eTickets.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services.Interfaces
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        public Task<Movie> GetMovieById(int id);
        public Task<DropdownsVM> GetDropDownValues();
    }
}
