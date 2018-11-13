using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using CucumberBankApp.Models;

namespace CucumberBankApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/
        public IActionResult Account(string name, string balance)
        {
            // return "This is where it displays the balance";
            ViewData["name"] = name;
            ViewData["balance"] = NumeralsToEnglish.ParseNumberAsBalanceString(balance).ToUpper();
            return View();
        }
    }
}
