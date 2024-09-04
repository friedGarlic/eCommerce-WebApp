using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorServ; //use actual interface for unit testing, flexibility

        public ActorController(IActorService actorServ)
        {
            _actorServ = actorServ;
        }

        public async Task<IActionResult> Actors()
        {
            var actors = await _actorServ.GetAll();
 
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([Bind("FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}

            _actorServ.Add(actor);

            return RedirectToAction(nameof(Actors));
        }
    }
}
