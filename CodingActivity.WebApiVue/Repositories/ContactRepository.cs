using CodingActivity.WebApiVue.Data;
using CodingActivity.WebApiVue.Entities;
using CodingActivity.WebApiVue.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace CodingActivity.WebApiVue.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly CADBContext _context;

        public ContactRepository(CADBContext context)
        {
            this._context = context;
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            var newContact = await this._context.Contact.AddAsync(contact);
            await this._context.Address.AddAsync(contact.Address);
            await this._context.SaveChangesAsync();

            return
                await this.GetAsync(newContact.Entity.Id);
        }

        public async Task<Contact> DeleteAsync(int id)
        {
            var contact = await this._context.Contact.FirstOrDefaultAsync(c => c.Id == id);
            var contactRemove = this._context.Contact.Remove(contact);
            await this._context.SaveChangesAsync();

            return
                contactRemove.Entity;
        }

        public async Task<Contact> GetAsync(int id)
        {
            return
                await this._context.Contact
                        .Include(c => c.Address)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact[]> GetAllAsync(string sort)
        {
            return
                await this._context.Contact
                        .Include(c => c.Address)
                        .OrderBy(sort)
                        .AsNoTracking()
                        .ToArrayAsync();
        }

        public async Task<ContactFrequency[]> GetAllContactFrequencyAsync()
        {
            return
               await this._context.ContactFrequency
                       .AsNoTracking()
                       .ToArrayAsync();
        }

        public async Task<PreferredContactMethod[]> GetAllPreferredContactMethodAsync()
        {
            return
               await this._context.PreferredContactMethod
                       .AsNoTracking()
                       .ToArrayAsync();
        }

        public async Task<State[]> GetAllStateAsync()
        {
            return
               await this._context.State
                       .AsNoTracking()
                       .ToArrayAsync();
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            var contactToUpdate = await this._context.Contact.FirstOrDefaultAsync(c => c.Id == contact.Id);
            var addressToUpdate = await this._context.Address.FirstOrDefaultAsync(a => a.Id == contact.Id);

            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.PhoneNumber = contact.PhoneNumber;
                contactToUpdate.ContactFrequency = contact.ContactFrequency;
                contactToUpdate.PreferredContactMethod = contact.PreferredContactMethod;

                if (contactToUpdate != null)
                {
                    addressToUpdate.Street = contact.Address.Street;
                    addressToUpdate.City = contact.Address.City;
                    addressToUpdate.State = contact.Address.State;
                    addressToUpdate.Zip = contact.Address.Zip;
                }

                await this._context.SaveChangesAsync();

                return
                    await this.GetAsync(contact.Id);
            }
            else
                return
                    null;
        }
    }
}
