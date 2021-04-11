using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using Cqrs.Domain;

namespace Cqrs.Database
{
    public class Repository : IRepository
    {
        private readonly List<Domain.Person> _people;
        public Repository()
        {
            _people = new Faker<Domain.Person>().
                CustomInstantiator(f => Domain.Person.Create(Guid.NewGuid(),
                    f.Person.FirstName,
                    f.Person.LastName,
                    f.Person.DateOfBirth))
                .Generate(100);
        }

        public List<Domain.Person> GetPeople(string name, PaginationFilter pagination = null)
        {
            var people = _people;
            if (!string.IsNullOrWhiteSpace(name))
            {
                people = _people.Where(x => x.Name.Contains(name,
                    StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (pagination != null)
            {
                var skip = (pagination.PageNumber - 1) * pagination.PageSize;

                people = people.Skip(skip).Take(pagination.PageSize).ToList();
            }

            return people;
        }

        public void AddPerson(Domain.Person person)
        {
            _people.Add(person);
        }
    }
}
