using BankApp.Models;
using BankApp.Repositories;
using System;

namespace BankApp.Factories
{
    public class BankTransfersFactory : IBankTransfersFactory
    {
        public readonly IBankTransfersRepository _bankTransfersRepository;

        public BankTransfer Create()
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

            _bankTransfersRepository.Add(result);

            return result;
        }
    }

    public interface IBankTransfersFactory
    {
        BankTransfer Create();
    }
}
