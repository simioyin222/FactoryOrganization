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

  // GET: Machines/Create
  public IActionResult Create()
  {
  return View();
  }

  // POST: Machines/Create
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("MachineId,Name")] Machine machine)
  {
  if (ModelState.IsValid)
  {
  _db.Add(machine);
  await _db.SaveChangesAsync();
  return RedirectToAction(nameof(Index));
  }
  return View(machine);
  }

  // GET: Machines/Edit/5
  public async Task<IActionResult> Edit(int? id)
  {
  if (id == null)
  {
  return NotFound();
  }

  var machine = await _db.Machines.FindAsync(id);
  if (machine == null)
  {
  return NotFound();
  }
  return View(machine);
  }

  // POST: Machines/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, [Bind("MachineId,Name")] Machine machine)
  {
  if (id != machine.MachineId)
  {
  return NotFound();
  }

  if (ModelState.IsValid)
  {
  try
  {
    _db.Update(machine);
    await _db.SaveChangesAsync();
  }
  catch (DbUpdateConcurrencyException)
  {
    if (!MachineExists(machine.MachineId))
    {
    return NotFound();
    }
    else
    {
    throw;
    }
  }
  return RedirectToAction(nameof(Index));
  }
  return View(machine);
  }

  // GET: Machines/Delete/5
  public async Task<IActionResult> Delete(int? id)
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

  // POST: Machines/Delete/5
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
  var machine = await _db.Machines.FindAsync(id);
  _db.Machines.Remove(machine);
  await _db.SaveChangesAsync();
  return RedirectToAction(nameof(Index));
  }

  public IActionResult AddEngineer(int id)
{
  var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
  ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
  return View(thisMachine);
}

[HttpPost]
public IActionResult AddEngineer(Machine machine, int EngineerId)
{
  if (EngineerId != 0)
  {
    _db.EngineerMachine.Add(new EngineerMachine { MachineId = machine.MachineId, EngineerId = EngineerId });
    _db.SaveChanges();
  }
  return RedirectToAction("Index");
}

  private bool MachineExists(int id)
  {
  return _db.Machines.Any(e => e.MachineId == id);
  }
  }
}