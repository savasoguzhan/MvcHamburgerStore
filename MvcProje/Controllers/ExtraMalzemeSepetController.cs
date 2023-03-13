using Microsoft.AspNetCore.Mvc;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class ExtraMalzemeSepetController : Controller
    {
        public IActionResult Index(extraMalzemeCartViewModel extraVm)
        {
            return View(extraVm);
        }
    }
}
