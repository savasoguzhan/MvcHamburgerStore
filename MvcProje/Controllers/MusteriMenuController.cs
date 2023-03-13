using Microsoft.AspNetCore.Mvc;
using MvcProje.Areas.Identity.Data;
using MvcProje.Areas.Identity.Data.Classes;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class MusteriMenuController : Controller
    {
        private readonly UygulamaDbContext _db;

        public MusteriMenuController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Menu> MenuList = _db.Menuler.ToList();
            return View(MenuList);
        }

        public IActionResult ExtraMalzeme()
        {
            IEnumerable<ExtraMalzeme> extraList = _db.ExtraMalzemes.ToList();
            return View(extraList);
        }

        public IActionResult Yummy(int id)
        {
            ShoppingCart cartObj = new()
            {
                Adet = 1,
                Menu = _db.Menuler.Find(id)

            };
            
            return View(cartObj);

        }

        public IActionResult ExtraMalzemeCart(int id)
        {
            extraMalzemeCartViewModel extracartObj = new()
            {
                Adet = 1,
                extraMalzeme =_db.ExtraMalzemes.Find(id)

            };
            return View(extracartObj);
        }

    }
}
