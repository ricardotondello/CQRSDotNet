using System;

namespace Cqrs.Contracts.Contracts.Requests
{
    public class AddPersonRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
