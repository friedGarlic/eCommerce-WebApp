using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Movies()
        {
            var movieList = await _service.GetAllAsync(c => c.Cinema, p => p.Producer);

            return View(movieList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetMovieById(id);

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var getDropdown = await _service.GetDropDownValues();

            ViewBag.Cinemas = new SelectList(getDropdown.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(getDropdown.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(getDropdown.Producers, "Id", "FullName");

            return View();
        }
    }
}
