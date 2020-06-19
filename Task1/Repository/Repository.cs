using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task1.Repository
{
    public class Repository : IRepository
    {
        private readonly AzureDbContext _context;

        public Repository(AzureDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetAsync(int personId)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.PersonId == personId);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.Set<Person>().Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int personId)
        {
            var person = _context.People.FirstOrDefault(x => x.PersonId == personId);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}