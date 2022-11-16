using System.ComponentModel.DataAnnotations;

using BED_W4_Exercise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BED_W4_Exercise.Pages.Contact
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public StoreContactInfo Service { get; set; }

        public IndexModel(StoreContactInfo service)
        {
            Service = service;
            Input = new InputModel {};
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetDetails(string contact) {
            return RedirectToPage("/Contact/Details", new { Contact = contact });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
               return Page();
            }
            Service.Contacts.Add(new Models.Contact {
                Email = Input.Email,
                Name = Input.Name,
                PhoneNumber = Input.PhoneNumber
            });
            return RedirectToPage("Index");
        }
    }


        public class InputModel {
            [Required]
            [EmailAddress]
            public String Email { get; set; } = "";
            [Required]
            public String Name { get; set; } = "";
            [Required]
            [Phone]
            public String PhoneNumber { get; set; } = "";
        }
}
