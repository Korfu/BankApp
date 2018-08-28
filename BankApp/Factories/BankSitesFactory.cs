using BankApp.Models;
using BankApp.Repositories;
using System;

namespace BankApp.Factories
{
    public class BankSitesFactory : IBankSitesFactory
    {
        public readonly IBankSitesRepository _bankSitesRepository;

        public BankSite Create()
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

            _bankSitesRepository.Add(result);

            return result;
        }
    }

    public interface IBankSitesFactory
    {
        BankSite Create();
    }
}
