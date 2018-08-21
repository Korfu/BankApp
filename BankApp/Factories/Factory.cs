using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories
{
    public class Factory
    {
        public Account CreateAccount()
        {
            var result = new Account();

            Console.WriteLine("Creating an account:");
            Console.WriteLine("Account Id:");
            result.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Account Name:");
            result.Name = Console.ReadLine();
            Console.WriteLine("Account Number:");
            result.Number = Console.ReadLine();
            Console.WriteLine("Account Value:");
            result.Value = decimal.Parse(Console.ReadLine());
            return result;
        }

        public BankSite CreateBankSite()
        {
            var result = new BankSite();

            Console.WriteLine("Creating a bank site:");
            Console.WriteLine("Bank site Id:");
            result.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Bank site Name:");
            result.Name = Console.ReadLine();
            Console.WriteLine("Bank site address street:");
            result.AddressStreet = Console.ReadLine();
            Console.WriteLine("Bank site address street number:");
            result.AddressStreetNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Bank site address city:");
            result.AddressCity = Console.ReadLine();
            Console.WriteLine("Bank site address postal code:");
            result.AddressPostalCode = Console.ReadLine();
            return result;
        }

        public BankTransfer CreateBankTransfer()
        {
            var result = new BankTransfer();

            Console.WriteLine("Creating a bank transfer:");
            Console.WriteLine("Bank transfer Id:");
            result.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Source account number");
            result.SourceAccountNumber = Console.ReadLine();
            Console.WriteLine("Target account number");
            result.TargetAccountNumber = Console.ReadLine();
            Console.WriteLine("Value:");
            result.Value = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Title:");
            result.Title = Console.ReadLine();
            Console.WriteLine("Description:");
            result.Description = Console.ReadLine();
            Console.WriteLine("Time created:");
            result.TimeCreated = DateTime.Parse(Console.ReadLine());
            return result;
        }
    }
}
