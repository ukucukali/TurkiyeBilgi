using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TurkiyeBilgi.Models
{
    public class HomeViewModel
    {
        public int? BolgeId { get; set; }
        public List<Sehir> Sehirler { get; set; }
        public List<SelectListItem> Bolgeler { get; set; }
    }
}
