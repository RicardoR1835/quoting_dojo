using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojoCsharp.Models;
using DbConnection;

namespace quoting_dojoCsharp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult Create(Quote quote)
        {
            if(ModelState.IsValid){
                string query = $"INSERT INTO quote (Name, Content, created_at, updated_at) VALUES('{quote.Name}', '{quote.Content}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Show");
            }
            else{
                return View("Index");
            }
        }

        [HttpGet("quotes")]
        public IActionResult Show(){
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quote ORDER BY created_at DESC");
            Console.WriteLine(AllQuotes);
            ViewBag.Quotes = AllQuotes;
            return View();
        }

    }
}
