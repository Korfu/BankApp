using BankApp.Attributes;
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
        [ExcelMetadata("Numer konta nadawcy", 1)]
        public string SourceAccountNumber { get; set; }
        [ExcelMetadata("Numer konta odbiorcy", 2)]
        public string TargetAccountNumber { get; set; }
        [ExcelMetadata("Wartość przesłanych środków", 3)]
        public decimal Value { get; set; }
        [ExcelMetadata("Tytuł", 4)]
        public string Title { get; set; }
        [ExcelMetadata("Opis", 5)]
        public string Description { get; set; }
        [ExcelMetadata("Czas stworzenia(dd/MM/YYYY HH:mm)", 6)]
        public DateTime TimeCreated { get; set; }

        public void Display()
        {
            Console.WriteLine("displaying Bank site...");
            Console.WriteLine($"Id :{Id}");
            Console.WriteLine($"SourceAccountNumber :{SourceAccountNumber}");
            Console.WriteLine($"TargetAccountNumber :{TargetAccountNumber}");
            Console.WriteLine($"Value :{Value}");
            Console.WriteLine($"Title :{Title}");
            Console.WriteLine($"Description :{Description}");
            Console.WriteLine($"TimeCreated :{TimeCreated}");
        }
    }
}
