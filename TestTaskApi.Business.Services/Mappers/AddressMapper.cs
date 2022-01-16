using Contracts;
using TestTaskApi.Domain.Core;

namespace TestTaskApi.Business.Services.Mappers
{
    public static class AddressMapper
    {
        public static Address ToModel(this AddressDto addressDto)
        {
            if (addressDto is null) return null;

            Address address = new()
            {
                City = addressDto.City,
                AddressLine = addressDto.AddressLine,
            };
            return address;
        }

        public static AddressDto ToDto(this Address address)
        {
            if (address is null) return null;

            AddressDto addressDto = new()
            {
                City = address.City,
                AddressLine = address.AddressLine,
            };
            return addressDto;
        }
    }
}
