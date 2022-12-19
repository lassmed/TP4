using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using TP4.Models;
using TP4.Data;

namespace TP4.Controllers
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
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            Debug.WriteLine("UniversityContext is instantiated {0} times", UniversityContext.count);
            List<Student> s = universityContext.Student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("Student {0} {1} {2} {3}  ", student.id, student.first_name, student.last_name, student.phone_number);
            }
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
    }
}