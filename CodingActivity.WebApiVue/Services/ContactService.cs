using CodingActivity.WebApiVue.Entities;
using CodingActivity.WebApiVue.Repositories;
using CodingActivity.WebApiVue.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingActivity.WebApiVue.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _contactRepo;

        public ContactService(ContactRepository contactRepo)
        {
            this._contactRepo = contactRepo;
        }

        public async Task<Contact> Add(Contact contact)
        {
            return
                await this._contactRepo.AddAsync(contact);
        }

        public async Task<Contact> Get(int id)
        {
            return
                await this._contactRepo.GetAsync(id);
        }

        public async Task<Contact[]> GetAll(string sort)
        {
            return
                await this._contactRepo.GetAllAsync(sort);
        }

        public async Task<Contact> Remove(int id)
        {
            return
                await this._contactRepo.DeleteAsync(id);
        }

        public async Task<Contact> Update(Contact contact)
        {
            return
                 await this._contactRepo.UpdateAsync(contact);
        }

        public async Task<object[]> GetDropDown(string dropDowns)
        {
            string[] dropdownNames;
            List<object> result;

            dropdownNames = dropDowns.ToLower().Split(',');
            result = new List<object>();

            foreach (string dropDown in dropdownNames)
            {
                switch (dropDown)
                {
                    case "state":
                        result.Add(new
                        {
                            name = "state",
                            data = await this._contactRepo.GetAllStateAsync()
                        });
                        break;
                    case "contactfrequency":
                        result.Add(new
                        {
                            name = "contactfrequency",
                            data = await this._contactRepo.GetAllContactFrequencyAsync()
                        });
                        break;
                    case "preferredcontactmethod":
                        result.Add(new
                        {
                            name = "preferredcontactmethod",
                            data = await this._contactRepo.GetAllPreferredContactMethodAsync()
                        });
                        break;
                }
            }

            return
                result.ToArray();
        }
    }
}