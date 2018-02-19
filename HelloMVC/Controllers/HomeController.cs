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



        private static int TotalCounter = 0;

        
        

        public string CreateMessage(string name, string language)
        {
            return string.Format(Greetings[language], name);
        }

        public IActionResult Index()
        {   //default GET

            return View();
        }

        [HttpPost] // form submit POST 
        [Route("home/")] // absolute path 
        public IActionResult Greeting(string name, string language)
        {

            // this is a ternary statement. it reads left to right "if true ? do this : else do this"
            // if the user has a cookie containing the "counter" field then set the userCounter variable to its value
            // else set the value = 0
            int userCounter = Request.Cookies.ContainsKey("counter") ? int.Parse(Request.Cookies["counter"]) : 0;
            // increment and return the userCounter value. storing the returned counter value in the ViewBag
            ViewBag.userCounter = ++userCounter;
            // append a cookie with a "counter" field to the Response. set its value to the (now incremented) userCounter variable
            Response.Cookies.Append("counter", userCounter.ToString());
            ViewBag.greetingMessage = CreateMessage(name, language);
            ViewBag.Totalcounter = ++TotalCounter;
            
            return View(); 
            




        }
    }
}
