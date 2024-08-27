using eTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ActorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Actors()
        {
            var actors = _dbContext.Actors.ToList();
 
            return View(actors);
        }
    }
}
