using CodingActivity.WebApiVue.Entities;
using System.Threading.Tasks;

namespace CodingActivity.WebApiVue.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> GetAllAsync(string sort);
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<ContactFrequency[]> GetAllContactFrequencyAsync();
        Task<PreferredContactMethod[]> GetAllPreferredContactMethodAsync();
        Task<State[]> GetAllStateAsync();
    }
}
