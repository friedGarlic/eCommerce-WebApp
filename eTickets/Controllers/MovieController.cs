using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using eTickets.Models.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM newMovieModel)
        {
            await _service.CreateMovie(newMovieModel);

            return RedirectToAction("Movies");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieModel = await _service.GetMovieById(id);

            var movieVm = new MovieVM()
            {
                Id = movieModel.Id,
                Name = movieModel.Name,
                Description = movieModel.Description,
                Price = movieModel.Price,
                StartDate = movieModel.StartDate,
                EndDate = movieModel.EndDate,
                ProducerId = movieModel.ProducerId,
                CinemaId = movieModel.CinemaId,
                Category = movieModel.Category,
                ImageUrl = movieModel.ImageUrl,
                ActorIds = movieModel.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
            var getDropdown = await _service.GetDropDownValues();

            ViewBag.Cinemas = new SelectList(getDropdown.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(getDropdown.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(getDropdown.Producers, "Id", "FullName");

            return View(movieVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM modelVm)
        {
            await _service.EditMovie(modelVm);

            return RedirectToAction("Movies");
        }

        public async Task<IActionResult> Filter(string filterString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema );

            if (filterString != null)
            {
                var filteredMovies = allMovies.Where(n => n.Name.ToLower().Contains(filterString.ToLower()) || n.Description.Contains(filterString));

                return View(nameof(Movies), filteredMovies);
            }

            return View(nameof(Movies), allMovies);
        }
    }
}
