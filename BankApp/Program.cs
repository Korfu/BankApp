using System;
using BankApp.Helpers;
using Unity;
using BankApp.Commands;

namespace BankApp
{
    public class Program
    {
        private static readonly IConsoleHelper _consoleHelper = IoC.Container.Resolve<IConsoleHelper>();

        [STAThread]
        public static void Main(string[] args)
        {

            do
            {
                try
                {
                    DisplayMainMenu();
                    ChooseMainMenuItem();
                    _consoleHelper.WriteLine("Press escape to exit or any key to go again");
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
            } while (_consoleHelper.ReadKey() != ConsoleKey.Escape);
        }

        private static void DisplayMainMenu()
        {
            _consoleHelper.WriteLine("Main menu:");
            _consoleHelper.WriteLine("1) Create entity");
            _consoleHelper.WriteLine("2) Display entities");
            _consoleHelper.WriteLine("3) Download excel template");
            _consoleHelper.WriteLine("4) Import data from excel template");
        }

        private static void ChooseMainMenuItem()
        {
            var chosenOption = _consoleHelper.ReadKey();
            switch (chosenOption)
            {
                case ConsoleKey.D1:
                    IoC.Container.Resolve<ICreateEntityCommand>().Execute();
                    break;
                case ConsoleKey.D2:
                    IoC.Container.Resolve<IDisplayEntitiesCommand>().Execute();
                    break;
                case ConsoleKey.D3:
                    IoC.Container.Resolve<IGetExcelTemplateCommand>().Execute();
                    break;
                case ConsoleKey.D4:
                    IoC.Container.Resolve<IGetDataFromExcelTemplateCommand>().Execute();
                    break;
                case ConsoleKey.Escape:
                    _consoleHelper.WriteLine("Exiting...");
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, please try again");
                    _consoleHelper.WriteLine("");
                    ChooseMainMenuItem();
                    break;
            }
        }
    }
}
