using BmesRestApi.Messages.DataTransferObjects.Addresses;
using BmesRestApi.Models.Addresses;

namespace BmesRestApi.Messages.Extensions
{
    public static class AddressMappingExtensions
    {
        public static Address MapToAddress(this AddressDto addressDto)
        {
            var address = new Address
            {
                Id = addressDto.Id,
                Name = addressDto.Name,
                AddressLine1 = addressDto.AddressLine1,
                AddressLine2 = addressDto.AddressLine2,
                City = addressDto.City,
                Country = addressDto.Country,
                State = addressDto.State,
                ZipCode = addressDto.ZipCode,
                CreatedDate = addressDto.CreatedDate,
                ModifiedDate = addressDto.ModifiedDate,
                IsDeleted = addressDto.IsDeleted
            };

            return address;
        }

        public static AddressDto MapToAddressDto(this Address address)
        {
            var addressDto = new AddressDto
            {
                Id = address.Id,
                Name = address.Name,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                Country = address.Country,
                State = address.State,
                ZipCode = address.ZipCode,
                CreatedDate = address.CreatedDate,
                ModifiedDate = address.ModifiedDate,
                IsDeleted = address.IsDeleted
            };

            return addressDto;
        }
    }
}
