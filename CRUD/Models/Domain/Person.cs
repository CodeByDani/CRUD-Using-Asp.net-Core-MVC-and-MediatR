using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public DateTime DateOFBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
