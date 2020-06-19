using System.Threading.Tasks;

namespace Task1.Repository
{
    public interface IRepository
    {
        Task AddAsync(Person person);
        Task<Person> GetAsync(int personId);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int personId);
    }
}