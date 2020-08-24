namespace CodingActivity.WebApiVue.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ContactFrequency { get; set; }
        public int PreferredContactMethod { get; set; }
    }
}