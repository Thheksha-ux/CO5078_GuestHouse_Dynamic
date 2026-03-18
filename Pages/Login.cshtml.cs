using CO5078_GuestHouse_Dynamic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CO5078_GuestHouse_Dynamic.Pages
{
    public class LoginModel : PageModel
    {
        private readonly GuestHouseContext _context;

        public LoginModel(GuestHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string Message { get; set; } = "";

        public IActionResult OnPost()
        {
            var user = _context.AdminUsers
                .FirstOrDefault(a => a.Email == Email && a.Password == Password);

            if (user != null)
            {
                HttpContext.Session.SetString("AdminUser", user.Email);
                return RedirectToPage("/Admin/Admin");
            }

            Message = "Invalid login details";
            return Page();
        }
    }
}