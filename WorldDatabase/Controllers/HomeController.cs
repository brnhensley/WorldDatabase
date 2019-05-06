using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;

namespace WorldDatabase.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
