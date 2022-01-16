using Contracts;
using TestTaskApi.Domain.Core;

namespace TestTaskApi.Business.Services.Mappers
{
    public static class PersonMapper
    {
        public static Person ToModel(this PersonDto personDto)
        {
            if (personDto is null) return null;

            Person person = new()
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Address = personDto.Address.ToModel(),
            };
            return person;
        }

        public static PersonDto ToDto(this Person person)
        {
            if (person is null) return null;

            PersonDto personDto = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address.ToDto(),
            };
            return personDto;
        }
    }
}
