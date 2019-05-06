using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;
using System;

namespace WorldDatabase.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/city")]
    public ActionResult Index()
    {

      List<City> citiesList = City.GetAll();
      return View(citiesList);
    }

    [HttpGet("/city/new")]
    public ActionResult New()
    {
      return View();
    }

    // [HttpPost("/city")]
    // public ActionResult Create(string word, string phrase)
    // {
    //   RepeatCounter newRepeatCounter = new RepeatCounter(word, phrase);
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpGet("/city/{id}")]
    // public ActionResult Show(int id)
    // {
    //   RepeatCounter repeatCounter = RepeatCounter.Find(id);
    //   return View(repeatCounter);
    // }
  }
}
