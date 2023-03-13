using Microsoft.AspNetCore.Mvc;
using MvcProje.Areas.Identity.Data;
using MvcProje.Areas.Identity.Data.Classes;
using MvcProje.Models;

namespace MvcProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly UygulamaDbContext _db;

        public MenuController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Menuler.ToList());
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Ekle(MenuViewModel menuVm)
        {
            Menu menu = new Menu();
            try
            {
                if(menuVm.Resim != null)
                {
                    var dosyaAdi = menuVm.Resim.FileName;
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);

                    var akisOrtami = new FileStream(konum, FileMode.Create);
                    menuVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close();
                    menu.Resim = dosyaAdi;
                }
            }
            catch (Exception)
            {

                TempData["durum"] = "hata olustu";
            }

            menu.MenuAd = menuVm.MenuAd;
            menu.MenuFiyat= menuVm.MenuFiyat;
            _db.Menuler.Add(menu);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var siliencekMenu = _db.Menuler.Find(id);
            if (siliencekMenu == null)
            {
                return NotFound();
            }

            return View(siliencekMenu);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public IActionResult SilOnay(int? id)
        {
            var obj = _db.Menuler.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Menuler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
