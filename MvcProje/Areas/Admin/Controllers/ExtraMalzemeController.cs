using Microsoft.AspNetCore.Mvc;
using MvcProje.Areas.Identity.Data;
using MvcProje.Areas.Identity.Data.Classes;
using MvcProje.Models;

namespace MvcProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraMalzemeController : Controller
    {
        private readonly UygulamaDbContext _db;

        public ExtraMalzemeController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var extraMalzeme = _db.ExtraMalzemes.ToList();
            return View(extraMalzeme);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(ExtraMalzemeViewModel extraVm)
        {
            ExtraMalzeme extraMalzeme = new ExtraMalzeme();

            try
            {
                if(extraVm.Resim != null)
                {
                    var dosyaAdi = extraVm.Resim.FileName;
                    //dosyanin gelecegi konumu belirler
                    var konum = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img", dosyaAdi);

                    var akisOrtami = new FileStream(konum, FileMode.Create);
                    extraVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close();
                    extraMalzeme.Resim = dosyaAdi;
                }
            }
            catch (Exception)
            {

                TempData["DURUM"] = "hata olustu";
            }

            extraMalzeme.Ad = extraVm.Ad;
            extraMalzeme.Fiyat= extraVm.Fiyat;

            _db.ExtraMalzemes.Add(extraMalzeme);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Sil(int? id )
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var siliencekExtraMalzeme = _db.ExtraMalzemes.Find(id);
            if(siliencekExtraMalzeme == null)
            {
                return NotFound();
            }

            return View(siliencekExtraMalzeme);
        }

        [HttpPost,ValidateAntiForgeryToken,ActionName("Sil")]
        public IActionResult SilOnay(int? id)
        {
            var obj = _db.ExtraMalzemes.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            _db.ExtraMalzemes.Remove(obj);
                _db.SaveChanges();
            return RedirectToAction("index");

        }

    }
}
