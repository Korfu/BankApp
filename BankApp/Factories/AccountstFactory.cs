using BankApp.Helpers;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Factories
{
    public class AccountsFactory : IAccountsFactory
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IInputHelper _inputHelper;
        private readonly IConsoleHelper _consoleHelper;

        public AccountsFactory(IAccountsRepository accountsRepository, IInputHelper inputHelper,
            IConsoleHelper consoleHelper)
        {
            _accountsRepository = accountsRepository;
            _inputHelper = inputHelper;
            _consoleHelper = consoleHelper;
        }

        public Account Create()
        {
            var result = new Account();

            _consoleHelper.WriteLine("Creating an account:");
            _consoleHelper.WriteLine("Account Id:");
            result.Id = int.Parse(_consoleHelper.ReadLine());
            _consoleHelper.WriteLine("Account Name:");
            result.Name = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Account Number:");
            result.Number = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Account Value:");
            result.Value = decimal.Parse(_consoleHelper.ReadLine());

            _accountsRepository.Add(result);

            return result;
        }
    }

    public interface IAccountsFactory
    {
        Account Create();
    }
}
