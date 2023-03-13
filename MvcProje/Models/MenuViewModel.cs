namespace MvcProje.Models
{
    public class MenuViewModel
    {
        public string MenuAd { get; set; }

        public double MenuFiyat { get; set; }

        public IFormFile? Resim { get; set; } // kullanicin resim secebilmesi icin 
    }
}
