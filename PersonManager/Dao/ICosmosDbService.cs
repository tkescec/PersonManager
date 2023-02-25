using PersonManager.Models;

namespace PersonManager.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Person>> GetPersonsAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}
