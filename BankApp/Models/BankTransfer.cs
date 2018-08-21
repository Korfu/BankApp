using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankTransfer
    {
        public int Id { get; set; }
        public string SourceAccountNumber { get; set; }
        public string TargetAccountNumber { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
