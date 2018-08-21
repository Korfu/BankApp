﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public int AddressStreetNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }
    }
}