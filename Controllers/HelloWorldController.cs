using Microsoft.AspNetCore.Mvc;
using WebAppBookList.Models;

namespace WebAppBookList.Controllers
{
    public class HelloWorldController : Controller
    {
        private static List<DogViewModel> dogList = new List<DogViewModel>();

        public IActionResult Index()
        {
            return View(dogList);
        }
        public IActionResult Create()
        {
            var dogViewModel = new DogViewModel();
            return View(dogViewModel);  
        }

        public IActionResult CreateDog(DogViewModel dogViewModel) 
        {
            dogList.Add(dogViewModel);  
            return RedirectToAction(nameof(Index)); 
        }
        public string Hello()
        {
            return "Who's there?";
        }
    }
}
