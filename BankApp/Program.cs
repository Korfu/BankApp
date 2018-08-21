using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Program
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly BankSiteRepository _bankSiteRepository  = new BankSiteRepository();
        private static readonly BankTransferRepository _bankTransferRepository  = new BankTransferRepository();

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
                            //ExcelMethods.AddFile();
                            break;
                        case ConsoleKey.D2:
                            //ExcelMethods.ReadFile();
                            break;
                        case ConsoleKey.D3:
                           // CreateAccount();
                            break;
                        case ConsoleKey.D4:
                            //DisplayAllAccounts();
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
            Console.WriteLine("1) Add an Excel file");
            Console.WriteLine("2) Read an Excel file");
            Console.WriteLine("3) Create an Account");
            Console.WriteLine("4) Display all Accounts");
        }

      
        
    }
}
