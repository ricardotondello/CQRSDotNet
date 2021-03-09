using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cqrs.Domain
{
    public class Person
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public DateTime DateOfBirth { get; }

        private Person(){ }
        public Person(Guid id, string name, string surname, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
    }

    
    

}
