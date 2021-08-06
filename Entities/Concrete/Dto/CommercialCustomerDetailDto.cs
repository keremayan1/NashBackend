using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto
{
   public class CommercialCustomerDetailDto:IDto
    {
        public string MusteriNo { get; set; }
        public string Title { get; set; }
        public string TaxNumber { get; set; }
    }
}
