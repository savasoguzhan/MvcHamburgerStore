using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProje.Areas.Identity.Data;
using MvcProje.Migrations;
using MvcProje.Models;

namespace MvcProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class DashboardController : Controller
    {
        private readonly UygulamaDbContext _db;

        public DashboardController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var em = _db.ExtraMalzemes.ToList();
            var menu = _db.Menuler.ToList();
            var viewModel = new MalzemeMenuViewModel()
            {
                extramalzemeler = em,
                Menuler = menu
            };

            return View(viewModel);
        }
    }
}
