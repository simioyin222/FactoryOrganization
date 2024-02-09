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
    }
}