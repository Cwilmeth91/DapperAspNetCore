using Microsoft.AspNetCore.Mvc;

namespace DapperASPNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
