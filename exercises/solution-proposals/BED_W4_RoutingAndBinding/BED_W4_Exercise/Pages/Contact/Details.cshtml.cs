using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BED_W4_Exercise.Services;

namespace BED_W4_Exercise.Pages.Contact
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public InputModel? Input { get; set; } = null;
        private StoreContactInfo _service; 
        public DetailsModel(StoreContactInfo service) {
            _service = service;
        }
        public void OnGet(int index) 
        {
            if(index < _service.Contacts.Count) {
                var contact = _service.Contacts[index];
                Input = new InputModel {
                    Email = contact.Email,
                    Name = contact.Name,
                    PhoneNumber = contact.PhoneNumber
                };        
            }
        }
        public class InputModel {
            [Required]
            [EmailAddress]
            public String? Email { get; set; }
            [Required]
            public String? Name { get; set; }
            [Required]
            [Phone]
            public String? PhoneNumber { get; set; }
        }
    }
}
