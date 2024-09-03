using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly ActorService _actorServ;

        public ActorController(ActorService actorServ)
        {
            _actorServ = actorServ;
        }

        public async Task<IActionResult> Actors()
        {
            var actors = await _actorServ.GetAll();
 
            return View(actors);
        }
    }
}
