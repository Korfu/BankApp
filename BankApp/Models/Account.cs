using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }

        public void Display()
        {
            Console.WriteLine("displaying account...");
            Console.WriteLine($"Id :{Id}");
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"Number :{Number}");
            Console.WriteLine($"Value :{Value}");
        }
    }
}
