using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers;

public class HomeController : Controller
{
  private readonly FactoryContext _db;

  
  public HomeController(FactoryContext db)
  {
  _db = db;
  }

  public IActionResult Index()
  {
  var viewModel = new HomeIndexViewModel
  {
  Engineers = _db.Engineers.ToList(),
  Machines = _db.Machines.ToList()
  };
  return View(viewModel);
  }

  public IActionResult Privacy()
  {
  return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}