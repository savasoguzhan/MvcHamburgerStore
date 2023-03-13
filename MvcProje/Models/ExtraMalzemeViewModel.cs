namespace MvcProje.Models
{
    public class ExtraMalzemeViewModel
    {
        public string Ad { get; set; }
        public double Fiyat { get; set; }

        public IFormFile? Resim { get; set; } // kullanicin resim secebilmesi icin 
    }
}
