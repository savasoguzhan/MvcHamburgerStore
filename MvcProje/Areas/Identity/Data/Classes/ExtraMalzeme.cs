namespace MvcProje.Areas.Identity.Data.Classes
{
    public class ExtraMalzeme
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public double Fiyat { get; set; }

        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public string? Resim { get; set; }
    }
}
