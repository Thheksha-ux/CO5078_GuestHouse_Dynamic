using CO5078_GuestHouse_Dynamic.Data;
using CO5078_GuestHouse_Dynamic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace CO5078_GuestHouse_Dynamic.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private readonly GuestHouseContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminModel(GuestHouseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public List<Property> Properties { get; set; } = new();

        [BindProperty]
        public Property NewProperty { get; set; } = new();

        [BindProperty]
        public IFormFile? UploadedImage { get; set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
            {
                Response.Redirect("/Login");
                return;
            }

            Properties = _context.Properties.ToList();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
            {
                return RedirectToPage("/Login");
            }

            if (UploadedImage != null)
            {
                string extension = Path.GetExtension(UploadedImage.FileName);
                string fileName = Guid.NewGuid().ToString() + extension;
                string filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UploadedImage.CopyTo(stream);
                }

                NewProperty.MainImage = "/images/" + fileName;
            }

            _context.Properties.Add(NewProperty);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
            {
                return RedirectToPage("/Login");
            }

            var property = _context.Properties.Find(id);

            if (property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}