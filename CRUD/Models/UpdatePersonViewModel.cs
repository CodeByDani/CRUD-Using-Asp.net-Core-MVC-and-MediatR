using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class UpdatePersonViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOFBirth { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

    }
}
