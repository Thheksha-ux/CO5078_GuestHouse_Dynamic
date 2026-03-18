using CO5078_GuestHouse_Dynamic.Data;
using CO5078_GuestHouse_Dynamic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CO5078_GuestHouse_Dynamic.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly GuestHouseContext _context;

        public GalleryModel(GuestHouseContext context)
        {
            _context = context;
        }

        public List<GalleryImage> Images { get; set; } = new();

        public void OnGet()
        {
            Images = _context.GalleryImages.ToList();
        }
    }
}