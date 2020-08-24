using CodingActivity.WebApiVue.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodingActivity.WebApiVue.Data
{
    public class CADBContext : DbContext
    {
        public CADBContext(DbContextOptions<CADBContext> options) : base(options) { }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<ContactFrequency> ContactFrequency { get; set; }
        public DbSet<PreferredContactMethod> PreferredContactMethod { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(c => new { c.Id });
            modelBuilder.Entity<State>().HasKey(c => new { c.Code });
            modelBuilder.Entity<ContactFrequency>().HasKey(c => new { c.Id });
            modelBuilder.Entity<PreferredContactMethod>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Address>().HasKey(c => new { c.Id });

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Address)
                .WithOne();
        }

        public static void AddTestData(CADBContext context)
        {
            context.ContactFrequency.Add(new ContactFrequency { Id = 1, Frequency = "Contact only about account information" });
            context.ContactFrequency.Add(new ContactFrequency { Id = 2, Frequency = "OK to contact with marketing information" });
            context.ContactFrequency.Add(new ContactFrequency { Id = 3, Frequency = "OK to contact with third-party marketing information" });

            context.PreferredContactMethod.Add(new PreferredContactMethod { Id = 1, Method = "Text" });
            context.PreferredContactMethod.Add(new PreferredContactMethod { Id = 2, Method = "Email" });
            context.PreferredContactMethod.Add(new PreferredContactMethod { Id = 3, Method = "Phone" });

            context.State.Add(new State { StateName = "Alabama", Code = "AL" });
            context.State.Add(new State { StateName = "Alaska", Code = "AK" });
            context.State.Add(new State { StateName = "Arizona", Code = "AZ" });
            context.State.Add(new State { StateName = "Arkansas", Code = "AR" });
            context.State.Add(new State { StateName = "California", Code = "CA" });
            context.State.Add(new State { StateName = "Colorado", Code = "CO" });
            context.State.Add(new State { StateName = "Connecticut", Code = "CT" });
            context.State.Add(new State { StateName = "Delaware", Code = "DE" });
            context.State.Add(new State { StateName = "Florida", Code = "FL" });
            context.State.Add(new State { StateName = "Georgia", Code = "GA" });
            context.State.Add(new State { StateName = "Hawaii", Code = "HI" });
            context.State.Add(new State { StateName = "Idaho", Code = "ID" });
            context.State.Add(new State { StateName = "Illinois", Code = "IL" });
            context.State.Add(new State { StateName = "Indiana", Code = "IN" });
            context.State.Add(new State { StateName = "Iowa", Code = "IA" });
            context.State.Add(new State { StateName = "Kansas", Code = "KS" });
            context.State.Add(new State { StateName = "Kentucky", Code = "KY" });
            context.State.Add(new State { StateName = "Louisiana", Code = "LA" });
            context.State.Add(new State { StateName = "Maine", Code = "ME" });
            context.State.Add(new State { StateName = "Maryland", Code = "MD" });
            context.State.Add(new State { StateName = "Massachusetts", Code = "MA" });
            context.State.Add(new State { StateName = "Michigan", Code = "MI" });
            context.State.Add(new State { StateName = "Minnesota", Code = "MN" });
            context.State.Add(new State { StateName = "Mississippi", Code = "MS" });
            context.State.Add(new State { StateName = "Missouri", Code = "MO" });
            context.State.Add(new State { StateName = "Montana", Code = "MT" });
            context.State.Add(new State { StateName = "Nebraska", Code = "NE" });
            context.State.Add(new State { StateName = "Nevada", Code = "NV" });
            context.State.Add(new State { StateName = "New Hampshire", Code = "NH" });
            context.State.Add(new State { StateName = "New Jersey", Code = "NJ" });
            context.State.Add(new State { StateName = "New Mexico", Code = "NM" });
            context.State.Add(new State { StateName = "New York", Code = "NY" });
            context.State.Add(new State { StateName = "North Carolina", Code = "NC" });
            context.State.Add(new State { StateName = "North Dakota", Code = "ND" });
            context.State.Add(new State { StateName = "Ohio", Code = "OH" });
            context.State.Add(new State { StateName = "Oklahoma", Code = "OK" });
            context.State.Add(new State { StateName = "Oregon", Code = "OR" });
            context.State.Add(new State { StateName = "Pennsylvania", Code = "PA" });
            context.State.Add(new State { StateName = "Rhode Island", Code = "RI" });
            context.State.Add(new State { StateName = "South Carolina", Code = "SC" });
            context.State.Add(new State { StateName = "South Dakota", Code = "SD" });
            context.State.Add(new State { StateName = "Tennessee", Code = "TN" });
            context.State.Add(new State { StateName = "Texas", Code = "TX" });
            context.State.Add(new State { StateName = "Utah", Code = "UT" });
            context.State.Add(new State { StateName = "Vermont", Code = "VT" });
            context.State.Add(new State { StateName = "Virginia", Code = "VA" });
            context.State.Add(new State { StateName = "Washington", Code = "WA" });
            context.State.Add(new State { StateName = "West Virginia", Code = "WV" });
            context.State.Add(new State { StateName = "Wisconsin", Code = "WI" });
            context.State.Add(new State { StateName = "Wyoming", Code = "WY" });

            context.Contact.Add(new Contact { Id = 1, FirstName = "Rabel", LastName = "Obispo", Email = "hey@hey.com", PhoneNumber = "18008808980", ContactFrequency = 1, PreferredContactMethod = 1 });
            context.Contact.Add(new Contact { Id = 2, FirstName = "Alex", LastName = "Mc", Email = "Alex@hey.com", PhoneNumber = "18008808981", ContactFrequency = 2, PreferredContactMethod = 3 });
            context.Contact.Add(new Contact { Id = 3, FirstName = "Cardi", LastName = "B", Email = "Cardi@hey.com", PhoneNumber = "18008808982", ContactFrequency = 3, PreferredContactMethod = 2 });
            context.Contact.Add(new Contact { Id = 4, FirstName = "Amazon", LastName = "LLC", Email = "Amazon@hey.com", PhoneNumber = "18008808983", ContactFrequency = 2, PreferredContactMethod = 1 });
            context.Contact.Add(new Contact { Id = 5, FirstName = "Apple", LastName = "Inc.", Email = "Apple@hey.com", PhoneNumber = "18008808984", ContactFrequency = 3, PreferredContactMethod = 3 });
            context.Contact.Add(new Contact { Id = 6, FirstName = "Microsoft", LastName = "Corp.", Email = "Microsoft@hey.com", PhoneNumber = "18008808985", ContactFrequency = 1, PreferredContactMethod = 1 });
            context.Contact.Add(new Contact { Id = 7, FirstName = "Tesla", LastName = "Inc.", Email = "Tesla@hey.com", PhoneNumber = "18008808986", ContactFrequency = 3, PreferredContactMethod = 2 });
            context.Contact.Add(new Contact { Id = 8, FirstName = "Facebook", LastName = "Corp", Email = "Facebook@hey.com", PhoneNumber = "18008808987", ContactFrequency = 2, PreferredContactMethod = 3 });
            context.Contact.Add(new Contact { Id = 9, FirstName = "Twitter", LastName = "Inc.", Email = "Twitter@hey.com", PhoneNumber = "18008808988", ContactFrequency = 3, PreferredContactMethod = 2 });
            context.Contact.Add(new Contact { Id = 10, FirstName = "Coca", LastName = "Cola", Email = "Coca@hey.com", PhoneNumber = "18008808989", ContactFrequency = 1, PreferredContactMethod = 1 });

            context.Address.Add(new Address { Id = 1, ContactId = 1, Street = "711-2880 Nulla St.", City = "Mankato", Zip = "01245" });
            context.Address.Add(new Address { Id = 2, ContactId = 2, Street = "P.O. Box 283 8562 Fusce Rd.", City = "Frederick", Zip = "01245" });
            context.Address.Add(new Address { Id = 3, ContactId = 3, Street = "606-3727 Ullamcorper. Street", City = "Roseville", Zip = "01245" });
            context.Address.Add(new Address { Id = 4, ContactId = 4, Street = "Ap #867-859 Sit Rd.", City = "Azusa", Zip = "01245" });
            context.Address.Add(new Address { Id = 5, ContactId = 5, Street = "7292 Dictum Av.", City = "San Antonio", Zip = "01245" });
            context.Address.Add(new Address { Id = 6, ContactId = 6, Street = "Ap #651-8679 Sodales Av.", City = "Tamuning", Zip = "01245" });
            context.Address.Add(new Address { Id = 7, ContactId = 7, Street = "191-103 Integer Rd.", City = "Corona", Zip = "01245" });
            context.Address.Add(new Address { Id = 8, ContactId = 8, Street = "P.O. Box 887 2508 Dolor. Av.", City = "Muskegon", Zip = "01245" });
            context.Address.Add(new Address { Id = 9, ContactId = 9, Street = "511-5762 At Rd.", City = "Chelsea", Zip = "01245" });
            context.Address.Add(new Address { Id = 10, ContactId = 10, Street = "935-9940 Tortor. Street", City = "Santa Rosa", Zip = "01245" });

            context.SaveChanges();
        }
    }
}
