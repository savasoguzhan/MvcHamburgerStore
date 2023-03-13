namespace MvcProje.Areas.Identity.Data.Classes
{
    public class Menu
    {
        public int Id { get; set; }

        public string MenuAd { get; set; }

        public double MenuFiyat { get; set; }

        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public string? Resim { get; set; }

    }
}
