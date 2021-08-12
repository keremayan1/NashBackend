using Core.Entities;

using System;

namespace Entities
{
    public   class Person:IEntity
    {
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}