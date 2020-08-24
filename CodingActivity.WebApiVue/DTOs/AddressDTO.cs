using System.ComponentModel.DataAnnotations;

namespace CodingActivity.WebApiVue.DTOs
{
    public class AddressDTO
    {
        [MaxLength(length: 100, ErrorMessage = "Maximum 100 characters")]
        public string Street { get; set; }
        [MaxLength(length: 50, ErrorMessage = "Maximum 50 characters")]
        public string City { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}