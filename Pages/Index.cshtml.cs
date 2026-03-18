using CO5078_GuestHouse_Dynamic.Data;
using CO5078_GuestHouse_Dynamic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CO5078_GuestHouse_Dynamic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GuestHouseContext _context;

        public IndexModel(GuestHouseContext context)
        {
            _context = context;
        }

        public Property? PropertyItem { get; set; }

        public void OnGet()
        {
            PropertyItem = _context.Properties
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();
        }
    }
}