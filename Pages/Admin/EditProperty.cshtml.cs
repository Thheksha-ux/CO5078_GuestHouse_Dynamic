using CO5078_GuestHouse_Dynamic.Data;
using CO5078_GuestHouse_Dynamic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CO5078_GuestHouse_Dynamic.Pages.Admin
{
    public class EditPropertyModel : PageModel
    {
        private readonly GuestHouseContext _context;

        public EditPropertyModel(GuestHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property PropertyItem { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            PropertyItem = _context.Properties.Find(id);

            if (PropertyItem == null)
            {
                return RedirectToPage("/Admin/Admin");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _context.Properties.Update(PropertyItem);
            _context.SaveChanges();

            return RedirectToPage("/Admin/Admin");
        }
    }
}