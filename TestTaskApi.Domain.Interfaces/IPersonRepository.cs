using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskApi.Domain.Core;

namespace TestTaskApi.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync(Person person);
        Task<long> UpsertAsync(Person person);
    }
}
