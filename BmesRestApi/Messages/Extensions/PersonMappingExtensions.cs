using BmesRestApi.Messages.DataTransferObjects.Shared;
using BmesRestApi.Models.Shared;

namespace BmesRestApi.Messages.Extensions
{
    public static class PersonMappingExtensions
    {
        public static Person MapToPerson(this PersonDto personDto)
        {
            var person = new Person
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                MiddleName = personDto.MiddleName,
                LastName = personDto.LastName,
                EmailAddress = personDto.EmailAddress,
                PhoneNumber = personDto.PhoneNumber,
                Gender = (Gender) personDto.Gender,
                DateOfBirth = personDto.DateOfBirth,
                CreatedDate = personDto.CreatedDate,
                ModifiedDate = personDto.ModifiedDate,
                IsDeleted = personDto.IsDeleted
            };

            return person;
        }

        public static PersonDto MapToPersonDto(this Person person)
        {
            var personDto = new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                PhoneNumber = person.PhoneNumber,
                Gender = (int)person.Gender,
                DateOfBirth = person.DateOfBirth,
                CreatedDate = person.CreatedDate,
                ModifiedDate = person.ModifiedDate,
                IsDeleted = person.IsDeleted
            };

            return personDto;
        }
    }
}
