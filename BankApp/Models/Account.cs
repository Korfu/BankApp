using BankApp.Attributes;
using System;

namespace BankApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [ExcelMetadata("Nazwa",1)]
        public string Name { get; set; }
        [ExcelMetadata("Numer", 2)]
        public string Number { get; set; }
        [ExcelMetadata("Środki na koncie", 3)]
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
