using MvcProje.Areas.Identity.Data.Classes;
using System.ComponentModel.DataAnnotations;

namespace MvcProje.Models
{
    public class extraMalzemeCartViewModel
    {
        public ExtraMalzeme extraMalzeme { get; set; }

        [Range(1, 100, ErrorMessage = "lutfen 1 ile 1000 arasinda Adet Giriniz")]
        public int Adet { get; set; }
    }
}
