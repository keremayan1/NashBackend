using Core.Entities;
using Entities.Abstract;
using System;

namespace Entities
{
    public  class Person:IPerson
    {
       
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}