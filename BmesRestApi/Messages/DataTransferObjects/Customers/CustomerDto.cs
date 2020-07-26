using System;
using System.Collections.Generic;
using BmesRestApi.Messages.DataTransferObjects.Addresses;

namespace BmesRestApi.Messages.DataTransferObjects.Customers
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string DateOfBirth { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; }
    }
}
