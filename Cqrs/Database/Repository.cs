using Bogus;
using System;
using System.Collections.Generic;

namespace Cqrs.Database
{
    public class Repository : IRepository
    {
        private readonly List<Domain.Person> _people;
        public Repository()
        {
            _people = new Faker<Domain.Person>().
                CustomInstantiator(f => new Domain.Person(Guid.NewGuid(),
                    f.Person.FirstName,
                    f.Person.LastName,
                    f.Person.DateOfBirth))
                .Generate(100);
        }

        public List<Domain.Person> GetPeople() => _people;

        public void AddPerson(Domain.Person person)
        {
            _people.Add(person);
        }
    }
}
