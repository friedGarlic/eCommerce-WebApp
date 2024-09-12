using eTickets.DataAccess.Data;
using eTickets.DataAccess.Repositories;
using eTickets.DataAccess.Repositories.Interfaces;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using eTickets.Models.Models;
using eTickets.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var query = await _context.Movies.Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<DropdownsVM> GetDropDownValues()
        {
            var response = new DropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task CreateMovie(MovieVM newMovieModel)
        {
            var model = new Movie {
                Name = newMovieModel.Name,
                Price = newMovieModel.Price,
                ImageUrl = newMovieModel.ImageUrl,
                StartDate = newMovieModel.StartDate,
                Category = newMovieModel.Category,
                EndDate = newMovieModel.EndDate,
                Description = newMovieModel.Description,
                CinemaId = newMovieModel.CinemaId,
                ProducerId = newMovieModel.ProducerId,
            };
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            foreach (var ids in newMovieModel.ActorIds)
            {
                var bridgeModel = new Actor_Movie
                {
                    ActorId = ids,
                    MovieId = model.Id
                };
                await _context.AddAsync(bridgeModel);
            }
            await _context.SaveChangesAsync();
        }
    }
}
