using Azure.Identity;
using eTickets.DataAccess.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProducerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Producers()
        {
            var prodList = await _dbContext.Producers.ToListAsync();

            //TODO use viewmodel to pass models for better structure

            return View(prodList);
        }
    }
}
