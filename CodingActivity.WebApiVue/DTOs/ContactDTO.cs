using System.ComponentModel.DataAnnotations;

namespace CodingActivity.WebApiVue.DTOs
{
    public class ContactDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(length: 20, ErrorMessage = "Maximum 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(length: 20, ErrorMessage = "Maximum 20 characters")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public AddressDTO Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ContactFrequency { get; set; }
        public int PreferredContactMethod { get; set; }
    }
}