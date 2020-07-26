using System.Collections.Generic;
using BmesRestApi.Models.Addresses;
using BmesRestApi.Models.Orders;
using BmesRestApi.Models.Shared;

namespace BmesRestApi.Models.Customers
{
    public class Customer : BaseObject
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
