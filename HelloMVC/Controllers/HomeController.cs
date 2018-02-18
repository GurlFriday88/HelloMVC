using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private static Dictionary<string, string> Greetings = new Dictionary<string, string>()
        {
            //initialize the dictionary with lang options and have format placeholder ready to accept name
            {"Spanish", "Hola {0}"},
            {"French", "Salut {0}" },
            {"Turkish", "Merhaba {0}"},
            {"Hindi", "Namaste {0}"},

        };

        private static int Counter = 0;

        public string CreateMessage(string name, string language)
        {
            return string.Format(Greetings[language], name);
        }

        public IActionResult Index()
        {   //default GET

            return View();
        }

        [HttpPost] // form submit POST 
        [Route("home/greeting")] // absolute path 
        public IActionResult Greeting(string name, string language)
        {
            ViewBag.greetingMessage = CreateMessage(name, language);
            ViewBag.counter = ++Counter;
            return View(); 
            




        }
    }
}
