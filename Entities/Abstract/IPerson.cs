using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
  public  interface IPerson
    {
         string NationalId { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         DateTime DateOfBirth { get; set; }
    }
}
