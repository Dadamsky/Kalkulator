using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien Dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Jan", Surname = "Kowalski"},
                new Dane {Name = "Marek", Surname = "Nowak"},
                new Dane {Name = "Anna", Surname = "Kowalska"},
            };
            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }
        public IActionResult Kalkulatorek(Kalkulatorek kalkulatorek)
        {
            ViewBag.dodawanie = $"Wynik Dodawania ->  {kalkulatorek.lb1 + kalkulatorek.lb2}";
            ViewBag.odejmowanie = $"Wynik Odejmowania -> {kalkulatorek.lb1 - kalkulatorek.lb2}";
            ViewBag.mnozenie = $"Wynik mnożenia -> {kalkulatorek.lb1 * kalkulatorek.lb2}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}