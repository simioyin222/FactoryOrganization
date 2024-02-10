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
  }
}