using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;

        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        // GET: Engineers
        public async Task<IActionResult> Index()
        {
            return View(await _db.Engineers.ToListAsync());
        }

        // GET: Engineers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _db.Engineers
                .FirstOrDefaultAsync(m => m.EngineerId == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }
		}
}