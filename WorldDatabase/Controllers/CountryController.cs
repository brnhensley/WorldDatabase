using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;
using System;

namespace WorldDatabase.Controllers
{
  public class CountryController : Controller
  {
    [HttpGet("/country")]
    public ActionResult Index()
    {

      List<Country> countriesList = Country.GetAll();
      return View(countriesList);
    }

    [HttpGet("/country/new")]
    public ActionResult New()
    {
      return View();
    }

    // [HttpPost("/country")]
    // public ActionResult Create(string word, string phrase)
    // {
    //   RepeatCounter newRepeatCounter = new RepeatCounter(word, phrase);
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpGet("/country/{id}")]
    // public ActionResult Show(int id)
    // {
    //   RepeatCounter repeatCounter = RepeatCounter.Find(id);
    //   return View(repeatCounter);
    // }
  }
}
