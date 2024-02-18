using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
