using Microsoft.AspNetCore.Mvc;
using MvcProje.Areas.Identity.Data;
using MvcProje.Areas.Identity.Data.Classes;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class SepetController : Controller
    {
        private readonly UygulamaDbContext _db;

        public SepetController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(ShoppingCart shoppingCart)
        {
            return View(shoppingCart);
        }

        //public IActionResult Mix()
        //{
        //    var em = _db.ExtraMalzemes.ToList();
        //    var menu = _db.Menuler.ToList();
        //    var viewModel = new MixCheckOutViewModel()
        //    {
        //        ShoppingCarts = menu,
        //        ExtraMalzemeches = em
        //    };

        //    return View(viewModel);
        //}
    }
}
