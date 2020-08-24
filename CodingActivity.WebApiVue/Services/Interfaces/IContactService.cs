using CodingActivity.WebApiVue.Entities;
using System.Threading.Tasks;

namespace CodingActivity.WebApiVue.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact[]> GetAll(string sort);
        Task<Contact> Get(int id);
        Task<Contact> Update(Contact contact);
        Task<Contact> Add(Contact contact);
        Task<Contact> Remove(int id);
        Task<object[]> GetDropDown(string dropDowns);
    }
}
