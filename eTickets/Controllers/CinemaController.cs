using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService service)
        {
            _cinemaService = service;
        }

        public async Task<IActionResult> Cinemas()
        {
            var cineLists = await _cinemaService.GetAll();

            return View(cineLists);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            await _cinemaService.Add(cinema);

            return RedirectToAction(nameof(Cinemas));
        }

        //CRUD OPERTAION
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _cinemaService.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Logo,Name,Description")]Cinema cinema)
        {
            await _cinemaService.Update(cinema);

            return RedirectToAction(nameof(Cinemas));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _cinemaService.GetById(id);

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _cinemaService.GetById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _cinemaService.DeleteAsync(id);

            return RedirectToAction(nameof(Cinemas));
        }
    }
}
