using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeVanTruBTH2.Data;
using LeVanTruBTH2.Models;

namespace LeVanTruBTH2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Customers.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer cs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cs);
        }
    }
}
