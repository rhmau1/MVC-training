using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebStatisMVC.Data;
using WebStatisMVC.Models;

namespace WebStatisMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebStatisMVCContext _context;

        public HomeController(ILogger<HomeController> logger, WebStatisMVCContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            /*return View();*/
            var articles = _context.Articles.ToList();

            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }        

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}