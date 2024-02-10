using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
  private readonly FactoryContext _db;

  public EngineersController(FactoryContext db)
  {
  _db = db;
  }

  public IActionResult Index()
  {
  return View(_db.Engineers.ToList());
  }

  public IActionResult Details(int id)
  {
  var thisEngineer = _db.Engineers
  .Include(engineer => engineer.Machines)
  .ThenInclude(join => join.Machine)
  .FirstOrDefault(engineer => engineer.EngineerId == id);
  return View(thisEngineer);
  }

  public IActionResult Create()
  {
  return View();
  }

  [HttpPost]
  public IActionResult Create(Engineer engineer)
  {
  _db.Engineers.Add(engineer);
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public IActionResult Edit(int id)
  {
  var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
  return View(thisEngineer);
  }

  [HttpPost]
  public IActionResult Edit(Engineer engineer)
  {
  _db.Entry(engineer).State = EntityState.Modified;
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public IActionResult Delete(int id)
  {
  var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
  return View(thisEngineer);
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeleteConfirmed(int id)
  {
  var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
  _db.Engineers.Remove(thisEngineer);
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public ActionResult AddMachine(int id)
{
  var engineer = _db.Engineers.Include(e => e.Machines).ThenInclude(em => em.Machine).FirstOrDefault(e => e.EngineerId == id);
  if (engineer == null)
  {
  return NotFound();
  }
  var engineerMachine = new EngineerMachine { EngineerId = id, Engineer = engineer }; // Ensure Engineer is loaded
  ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
  return View(engineerMachine);
}

  [HttpPost]
  public IActionResult AddMachine(EngineerMachine engineerMachine)
  {
  if (_db.EngineerMachines.Any(em => em.EngineerId == engineerMachine.EngineerId && em.MachineId == engineerMachine.MachineId))
  {
  return RedirectToAction(nameof(Details), new { id = engineerMachine.EngineerId });
  }
  _db.EngineerMachines.Add(engineerMachine);
  _db.SaveChanges();
  return RedirectToAction(nameof(Details), new { id = engineerMachine.EngineerId });
  }
  }
}