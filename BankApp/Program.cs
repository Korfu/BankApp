using BankApp.Factories;
using BankApp.Repositories;
using System;

namespace BankApp
{
    public class Program
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly BankSiteRepository _bankSiteRepository  = new BankSiteRepository();
        private static readonly BankTransferRepository _bankTransferRepository  = new BankTransferRepository();
        private static readonly Factory _factory = new Factory();

        [STAThread]
        public static void Main(string[] args)
        {

            do
            {
                try
                {
                    DisplayMainMenu();

                    var chosenOption = Console.ReadKey(true);
                    

                    switch (chosenOption.Key)
                    {
                        case ConsoleKey.D1:
                             var newAccount = _factory.CreateAccount();
                            _accountRepository.Add(newAccount);
                            break;
                        case ConsoleKey.D2:
                            var newBankSite = _factory.CreateBankSite();
                            _bankSiteRepository.Add(newBankSite);
                            break;
                        case ConsoleKey.D3:
                            var newBankTransfer = _factory.CreateBankTransfer();
                            _bankTransferRepository.Add(newBankTransfer);
                            break;
                        case ConsoleKey.D4:
                            DisplayAllAccounts();
                            break;
                        case ConsoleKey.D5:
                            DisplayAllBankSites();
                            break;
                        case ConsoleKey.D6:
                            DisplayAllBankTransfers();
                            break;
                        default:
                            Console.WriteLine("Wrong option chosen!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occured");
                    Console.WriteLine($"Exception message: { ex.Message }");
                }
                finally
                {
                    Console.WriteLine("Press escape to exit or any other key to go again");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("Hello to Excel Uploader!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Create an Account");
            Console.WriteLine("2) Create a Bank site"); ;
            Console.WriteLine("3) Create a Bank transfer");
            Console.WriteLine("4) Display all Accounts");
            Console.WriteLine("5) Display all Bank sites");
            Console.WriteLine("6) Display all Bank transfers");
        }

        private static void DisplayAllAccounts()
        {
            Console.WriteLine("Displaying all Accounts");
            var accountsList = _accountRepository.GetAll();
            foreach (var account in accountsList)
            {
                account.Display();
            }
        }

        private static void DisplayAllBankSites()
        {
            Console.WriteLine("Displaying all Bank sites");
            var bankSitesList = _bankSiteRepository.GetAll();
            foreach (var bankSite in bankSitesList)
            {
                bankSite.Display();
            }
        }

        private static void DisplayAllBankTransfers()
        {
            Console.WriteLine("Displaying all Bank transfers");
            var bankTransfersList = _bankTransferRepository.GetAll();
            foreach (var bankTransfer in bankTransfersList)
            {
                bankTransfer.Display();
            }
        }

    }
}
