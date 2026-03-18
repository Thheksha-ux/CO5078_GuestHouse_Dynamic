using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CO5078_GuestHouse_Dynamic.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactInput Input { get; set; } = new();

        public string Message { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Your message has been sent successfully.";
                Input = new ContactInput();
            }
        }

        public class ContactInput
        {
            [Required]
            public string Name { get; set; } = "";

            [Required]
            [EmailAddress]
            public string Email { get; set; } = "";

            [Required]
            public string UserMessage { get; set; } = "";
        }
    }
}