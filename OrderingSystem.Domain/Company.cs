using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Domain
{
    public class Company
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Street { get; init; }
        public int ZipCode { get; init; }
        public string City { get; init; }
        public string UIdNumber { get; init; }
        public string TelephoneNumber { get; init; }
    }
}
