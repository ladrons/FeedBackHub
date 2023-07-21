using FeedBackHub.Context;
using FeedBackHub.Models;
using FeedBackHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FeedBackHub.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        [HttpPost]
        public IActionResult SaveComment(VisitorVM vvm)
        {
            try
            {
                Visitor visitor = new Visitor
                {
                    Name = vvm.Name,
                    Comment = vvm.Comment,
                    CreatedDate = DateTime.Now
                };

                _context.Visitors.Add(visitor);
                _context.SaveChanges();

                TempData["Result"] = "Kayıt işlemi gerçekleştirildi.";

                return RedirectToAction(nameof(HomeController.Index));
            }
            catch (Exception ex)
            {
                TempData["Result"] = $"Kayıt sırasında hata meydana geldi. {ex.Message}";

                return RedirectToAction(nameof(HomeController.Index));
            }
        }
    }
}