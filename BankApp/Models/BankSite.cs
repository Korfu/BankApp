using BankApp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankSite
    {
        public int Id { get; set; }
        [ExcelMetadata("Nazwa", 1)]
        public string Name { get; set; }
        [ExcelMetadata("Ulica", 2)]
        public string AddressStreet { get; set; }
        [ExcelMetadata("Numer budynku", 3)]
        public int AddressStreetNumber { get; set; }
        [ExcelMetadata("Miasto", 4)]
        public string AddressCity { get; set; }
        [ExcelMetadata("Kod pocztowy", 5)]
        public string AddressPostalCode { get; set; }

        public void Display()
        {
            Console.WriteLine("displaying Bank site...");
            Console.WriteLine($"Id :{Id}");
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"AddressStreet :{AddressStreet}");
            Console.WriteLine($"AddressCity :{AddressCity}");
            Console.WriteLine($"AddressPostalCode :{AddressPostalCode}");
        }
    }
}
