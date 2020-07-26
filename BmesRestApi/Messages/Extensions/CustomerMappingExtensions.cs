using BmesRestApi.Messages.DataTransferObjects.Customers;
using BmesRestApi.Models.Customers;
using BmesRestApi.Models.Shared;

namespace BmesRestApi.Messages.Extensions
{
    public static class CustomerMappingExtensions
    {
        public static Customer MapToCustomer(this CustomerDto customerDto)
        {
            var person = new Person
            {
                Id = customerDto.Id,
                FirstName = customerDto.FirstName,
                MiddleName = customerDto.MiddleName,
                LastName = customerDto.LastName,
                EmailAddress = customerDto.EmailAddress,
                PhoneNumber = customerDto.PhoneNumber,
                Gender = (Gender) customerDto.Gender,
                DateOfBirth = customerDto.DateOfBirth,
                CreatedDate = customerDto.CreatedDate,
                ModifiedDate = customerDto.ModifiedDate,
                IsDeleted = customerDto.IsDeleted
            };

            return new Customer
            {
                Id = customerDto.Id,
                Person = person
            };
        }

        public static CustomerDto MapToCustomerDto(this Customer customer)
        {
            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.Person.FirstName,
                MiddleName = customer.Person.MiddleName,
                LastName = customer.Person.LastName,
                EmailAddress = customer.Person.EmailAddress,
                PhoneNumber = customer.Person.PhoneNumber,
                Gender = (int)customer.Person.Gender,
                DateOfBirth = customer.Person.DateOfBirth,
                CreatedDate = customer.CreatedDate,
                ModifiedDate = customer.ModifiedDate,
                IsDeleted = customer.IsDeleted
            };

            return customerDto;
        }
    }
}
