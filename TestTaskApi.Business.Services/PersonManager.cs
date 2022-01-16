using Contracts;
using JSONReaderWriter;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApi.Business.Services.Interfaces;
using TestTaskApi.Business.Services.Mappers;
using TestTaskApi.Domain.Interfaces;

namespace TestTaskApi.Business.Services
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<string> GetAllAsync(string filter)
        {
            GetAllRequestDto filterDto = filter.FromJson<GetAllRequestDto>();
            var result = (await _personRepository.GetAllAsync(filterDto.ToModel()))
                .Select(r => r.ToDto())
                .ToList();
            return result.Count == 1 ? result.First().ToJson() : result.ToJson();
        }

        public async Task<long> UpsertAsync(string input)
        {
            PersonDto person = input.FromJson<PersonDto>();
            return await _personRepository.UpsertAsync(person.ToModel());
        }
    }
}
