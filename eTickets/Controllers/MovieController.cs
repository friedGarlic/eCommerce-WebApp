using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
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

        public string Filter(string searchString)
        {
            return null;
        }
    }
}
