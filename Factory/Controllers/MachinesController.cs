using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
  private readonly FactoryContext _db;

  public MachinesController(FactoryContext db)
  {
  _db = db;
  }

  public IActionResult Index()
  {
  return View(_db.Machines.ToList());
  }

  public IActionResult Details(int id)
  {
  var thisMachine = _db.Machines
  .Include(machine => machine.Engineers)
  .ThenInclude(join => join.Engineer)
  .FirstOrDefault(machine => machine.MachineId == id);
  return View(thisMachine);
  }

  public IActionResult Create()
  {
  return View();
  }

  [HttpPost]
  public IActionResult Create(Machine machine)
  {
  _db.Machines.Add(machine);
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public IActionResult Edit(int id)
  {
  var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
  return View(thisMachine);
  }

  [HttpPost]
  public IActionResult Edit(Machine machine)
  {
  _db.Entry(machine).State = EntityState.Modified;
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public IActionResult Delete(int id)
  {
  var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
  return View(thisMachine);
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeleteConfirmed(int id)
  {
  var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
  _db.Machines.Remove(thisMachine);
  _db.SaveChanges();
  return RedirectToAction("Index");
  }

  public ActionResult AddEngineer(int id)
{
  var machine = _db.Machines.Include(m => m.Engineers).ThenInclude(em => em.Engineer).FirstOrDefault(m => m.MachineId == id);
  if (machine == null)
  {
  return NotFound();
  }
  var engineerMachine = new EngineerMachine { MachineId = id, Machine = machine }; // Ensure Machine is loaded
  ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
  return View(engineerMachine);
}

  [HttpPost]
  public IActionResult AddEngineer(EngineerMachine engineerMachine)
  {
  if (_db.EngineerMachines.Any(em => em.MachineId == engineerMachine.MachineId && em.EngineerId == engineerMachine.EngineerId))
  {
  return RedirectToAction(nameof(Details), new { id = engineerMachine.MachineId });
  }
  _db.EngineerMachines.Add(engineerMachine);
  _db.SaveChanges();
  return RedirectToAction(nameof(Details), new { id = engineerMachine.MachineId });
  }
  }
}