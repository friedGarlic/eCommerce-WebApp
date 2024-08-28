using eTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CinemaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Cinemas()
        {
            var cineLists = await _dbContext.Cinemas.ToListAsync();

            return View(cineLists);
        }
    }
}
