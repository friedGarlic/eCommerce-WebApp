using eTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CinemaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
