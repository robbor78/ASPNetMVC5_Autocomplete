using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult AutoComplete(string input)
    {
      var json = new JsonResult()
      {
        JsonRequestBehavior = JsonRequestBehavior.AllowGet
      };

      if (string.IsNullOrWhiteSpace(input))
      {
        json.Data = new string[] { };
      }
      else
      {
        var selection = words.Where(x => x.StartsWith(input));
        json.Data = selection;
      }
      return json;

      //return Json(new[]
      //{
      //  new {Word="apple" },
      //  new {Word="orange" },
      //  new {Word="pear" }
      //}, JsonRequestBehavior.AllowGet);
    }

    private static string[] words = new[] { "a", "ab", "abc", "b", "ba", "bac" };

  }
}
