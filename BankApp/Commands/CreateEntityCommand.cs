
using BankApp.Factories;
using BankApp.Helpers;
using System;

namespace BankApp.Commands
{
    class CreateEntityCommand : ICreateEntityCommand
    {
        private readonly IAccountsFactory _accountsFactory;
        private readonly IBankTransfersFactory _bankTransfersFactory;
        private readonly IBankSitesFactory _bankSitesFactory;

        private readonly IConsoleHelper _consoleHelper;

        public CreateEntityCommand(IAccountsFactory accountsFactory, IBankTransfersFactory bankTransfersFactory, IBankSitesFactory bankSitesFactory, IConsoleHelper consoleHelper)
        {
            _accountsFactory = accountsFactory;
            _bankTransfersFactory = bankTransfersFactory;
            _bankSitesFactory = bankSitesFactory;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Creating entity...");
            _consoleHelper.WriteLine("1) Account");
            _consoleHelper.WriteLine("2) Bank Transfer");
            _consoleHelper.WriteLine("3) Bank Site");
            var chosenOption = _consoleHelper.ReadKey();

            switch (chosenOption)
            {
                case ConsoleKey.D1:
                    _accountsFactory.Create();
                    break;
                case ConsoleKey.D2:
                    _bankSitesFactory.Create();
                    break;
                case ConsoleKey.D3:
                    _bankTransfersFactory.Create();;
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong option chosen!");
                    Execute();
                    break;
            }
        }
    }

    internal interface ICreateEntityCommand : ICommand
    {
    }
}
