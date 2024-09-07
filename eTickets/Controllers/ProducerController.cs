using Azure.Identity;
using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producer;

        public ProducerController(IProducerService producer)
        {
            _producer = producer;
        }

        public async Task<IActionResult> Producers()
        {
            var prodList = await _producer.GetAll();

            //TODO use viewmodel to pass models for better structure

            return View(prodList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")]Producer producer)
        {
            var model = await _producer.Add(producer);

            return RedirectToAction(nameof(Producers));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var foundId = await _producer.GetById(id);

            return View(foundId);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ProfilePictureUrl,FullName,Bio")]Producer producer)
        {
            await _producer.Update(producer);

            return RedirectToAction(nameof(Producers));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _producer.GetById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _producer.DeleteAsync(id);

            return RedirectToAction(nameof(Producers));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _producer.GetById(id);

            return View(model);
        }
    }
}
