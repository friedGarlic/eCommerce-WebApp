using eTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Movies()
        {
            var movieList = await _dbContext.Movies.ToListAsync();

            return View(movieList);
        }
    }
}
