namespace MvcProje.Models
{
    public class MixCheckOutViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }

        public IEnumerable<extraMalzemeCartViewModel> ExtraMalzemeches { get;set; }

    }
}
