using BankApp.Helpers;
using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands
{
    public class DisplayEntitiesCommand : IDisplayEntitiesCommand
    {
        private readonly IDisplayHelper _displayHelper;

        private readonly IAccountsRepository _accountsRepository;
        private readonly IBankTransfersRepository _bankTransfersRepository;
        private readonly IBankSitesRepository _bankSitesRepository;

        private readonly IConsoleHelper _consoleHelper;

        public DisplayEntitiesCommand(IDisplayHelper displayHelper,
            IAccountsRepository accountsRepository,
            IBankTransfersRepository bankTransfersRepository,
            IBankSitesRepository bankSitesRepository,
            IConsoleHelper consoleHelper)
        {
            _displayHelper = displayHelper;
            _accountsRepository = accountsRepository;
            _bankTransfersRepository = bankTransfersRepository;
            _bankSitesRepository = bankSitesRepository;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Displaying entinites...");
            _consoleHelper.WriteLine("1) Accounts");
            _consoleHelper.WriteLine("2) Bank Transfers");
            _consoleHelper.WriteLine("3) Bank Sites");

            var chosenOption = _consoleHelper.ReadKey();

            switch (chosenOption)
            {
                case ConsoleKey.D1:
                    DisplayAccounts();
                    break;
                case ConsoleKey.D2:
                    DisplayBankTransfers();
                    break;
                case ConsoleKey.D3:
                    DisplayBankSites();
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    _consoleHelper.WriteLine("Something went wrong... try again!");
                    Execute();
                    break;
            }
        }

        private void DisplayAccounts()
        {
            _consoleHelper.WriteLine("Displaying all Accounts");
            var accountsList = _accountsRepository.GetAll();
            foreach (var account in accountsList)
            {
                account.Display();
            }
        }

        private void DisplayBankTransfers()
        {
            _consoleHelper.WriteLine("Displaying all Bank transfers");
            var bankTransfersList = _bankTransfersRepository.GetAll();
            foreach (var bankTransfer in bankTransfersList)
            {
                bankTransfer.Display();
            }
        }

        private void DisplayBankSites()
        {
            _consoleHelper.WriteLine("Displaying all Bank sites");
            var bankSitesList = _bankSitesRepository.GetAll();
            foreach (var bankSite in bankSitesList)
            {
                bankSite.Display();
            }
        }
    }

        public interface IDisplayEntitiesCommand : ICommand
    {
    }
}
