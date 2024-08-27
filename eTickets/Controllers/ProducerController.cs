using eTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProducerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
