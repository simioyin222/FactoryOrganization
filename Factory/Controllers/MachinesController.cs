using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    // GET: Machines
    public async Task<IActionResult> Index()
    {
      return View(await _db.Machines.ToListAsync());
    }

    // GET: Machines/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machine = await _db.Machines
        .FirstOrDefaultAsync(m => m.MachineId == id);
      if (machine == null)
      {
        return NotFound();
      }

      return View(machine);
    }
  }
}