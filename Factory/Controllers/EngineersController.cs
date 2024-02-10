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

  // GET: Engineers/Create
  public IActionResult Create()
  {
  return View();
  }

  // POST: Engineers/Create
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("EngineerId,Name")] Engineer engineer)
  {
  if (ModelState.IsValid)
  {
  _db.Add(engineer);
  await _db.SaveChangesAsync();
  return RedirectToAction(nameof(Index));
  }
  return View(engineer);
  }

  // GET: Engineers/Edit/5
  public async Task<IActionResult> Edit(int? id)
  {
  if (id == null)
  {
  return NotFound();
  }

  var engineer = await _db.Engineers.FindAsync(id);
  if (engineer == null)
  {
  return NotFound();
  }
  return View(engineer);
  }

  // POST: Engineers/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, [Bind("EngineerId,Name")] Engineer engineer)
  {
  if (id != engineer.EngineerId)
  {
  return NotFound();
  }

  if (ModelState.IsValid)
  {
  try
  {
    _db.Update(engineer);
    await _db.SaveChangesAsync();
  }
  catch (DbUpdateConcurrencyException)
  {
    if (!EngineerExists(engineer.EngineerId))
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
  return View(engineer);
  }

  // GET: Engineers/Delete/5
  public async Task<IActionResult> Delete(int? id)
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

  // POST: Engineers/Delete/5
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
  var engineer = await _db.Engineers.FindAsync(id);
  _db.Engineers.Remove(engineer);
  await _db.SaveChangesAsync();
  return RedirectToAction(nameof(Index));
  }

  public IActionResult AddMachine(int id)
{
  var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
  ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
  return View(thisEngineer);
}

[HttpPost]
public IActionResult AddMachine(Engineer engineer, int MachineId)
{
  if (MachineId != 0)
  {
    _db.EngineerMachine.Add(new EngineerMachine { EngineerId = engineer.EngineerId, MachineId = MachineId });
    _db.SaveChanges();
  }
  return RedirectToAction("Index");
}

  private bool EngineerExists(int id)
  {
  return _db.Engineers.Any(e => e.EngineerId == id);
  }
  }
}