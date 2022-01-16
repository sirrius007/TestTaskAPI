using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApi.Domain.Core;
using TestTaskApi.Domain.Interfaces;

namespace TestTaskApi.Infrastructure.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TestTaskApiContext _db;
        public PersonRepository(TestTaskApiContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Person>> GetAllAsync(Person person)
        {
            if (person is null) 
                return await _db.Persons
                    .Include(p => p.Address)
                    .ToListAsync();
            return await _db.Persons
                .Include(p => p.Address)
                .Where(p => (string.IsNullOrEmpty(person.FirstName) || p.FirstName.ToLower() == person.FirstName.ToLower())
            && (string.IsNullOrEmpty(person.LastName) || p.LastName.ToLower() == person.LastName.ToLower())
            && (string.IsNullOrEmpty(person.Address.City) || p.Address.City.ToLower() == person.Address.City.ToLower())).ToListAsync();
        }

        public async Task<long> UpsertAsync(Person person)
        {
            var personFromDb = await GetAsync(person);
            if (personFromDb is null)
            {
                _db.Persons.Add(person);
            }
            else
            {
                personFromDb.Address.City = person.Address.City;
                personFromDb.Address.AddressLine = person.Address.AddressLine;
                _db.Persons.Update(personFromDb);
                person = personFromDb;
            }
            await _db.SaveChangesAsync();
            return person.Id;
        }

        private async Task<Person> GetAsync(Person person)
        {
            return await _db.Persons
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.FirstName.ToLower() == person.FirstName.ToLower()
            && p.LastName.ToLower() == person.LastName.ToLower());
        }
    }
}
