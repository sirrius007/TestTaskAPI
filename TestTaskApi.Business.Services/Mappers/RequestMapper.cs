using Contracts;
using TestTaskApi.Domain.Core;

namespace TestTaskApi.Business.Services.Mappers
{
    public static class RequestMapper
    {
        public static Person ToModel(this GetAllRequestDto request)
        {
            if (request is null)
                return null;

            Person person = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = new Address()
                {
                    City = request.City,
                },
            };
            return person;
        }
    }
}
