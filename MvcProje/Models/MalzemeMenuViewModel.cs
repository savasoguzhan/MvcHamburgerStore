using MvcProje.Areas.Identity.Data.Classes;

namespace MvcProje.Models
{
    public class MalzemeMenuViewModel
    {
        public IEnumerable<ExtraMalzeme> extramalzemeler { get; set; }

        public IEnumerable<Menu> Menuler { get; set; }
    }
}
