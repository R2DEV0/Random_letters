using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace RandomProj
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            // builds a random string on render //
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            int length = 15;
            char letter;
            for (int i =0; i<length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            // Generate count is placed into viewbag for display on page //
            int? Count = HttpContext.Session.GetInt32("Count");
            if(Count == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Count", (int)Count+1);
            }
            ViewBag.Count = HttpContext.Session.GetInt32("Count");

            // random string placed into viewbag for display on page //
            ViewBag.String = str_build.ToString();

            return View("Index");
        }


        [HttpGet("generate")]
        public ViewResult Counter()
        {
            return View("Index");
        }
    }
}
