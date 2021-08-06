﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class CommercialCustomer:IEntity
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string TaxNumber { get; set; }
        public bool Status { get; set; }



    }
}
