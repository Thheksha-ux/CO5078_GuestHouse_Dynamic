using CO5078_GuestHouse_Dynamic.Data;
using CO5078_GuestHouse_Dynamic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CO5078_GuestHouse_Dynamic.Pages
{
    public class PropertyDetailsModel : PageModel
    {
        private readonly GuestHouseContext _context;

        public PropertyDetailsModel(GuestHouseContext context)
        {
            _context = context;
        }

        public Property? PropertyItem { get; set; }
        public List<GalleryImage> Images { get; set; } = new();

        public void OnGet()
        {
            PropertyItem = _context.Properties
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (PropertyItem != null)
            {
                Images = _context.GalleryImages
                    .Where(g => g.PropertyId == PropertyItem.Id)
                    .ToList();
            }
        }
    }
}