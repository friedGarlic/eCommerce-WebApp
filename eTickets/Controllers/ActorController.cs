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
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}

            await _actorServ.Add(actor);

            return RedirectToAction(nameof(Actors));
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorServ.GetById(id);

            if (actorDetails == null)
            {
                return View("Empty");
            }

            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var getActor = await _actorServ.GetById(id);

            if (getActor == null)
            {
                return View("NotFound");
            }

            return View(getActor);
        } 

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName, ProfilePictureUrl, Bio")] Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}

            await _actorServ.Update(id, actor);

            return RedirectToAction(nameof(Actors));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var getActor = await _actorServ.GetById(id);

            if (getActor == null)
            {
                return View("NotFound");
            }

            return View(getActor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _actorServ.Delete(id);

            return RedirectToAction(nameof(Actors));
        }
    }
}
