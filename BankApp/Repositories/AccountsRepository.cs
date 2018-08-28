using System.Collections.Generic;
using System.Linq;
using BankApp.Models;

namespace BankApp.Repositories
{

    public class AccountsRepository : IAccountsRepository
    {
        private static List<Account> _allAccounts = new List<Account>();

        public void Add (Account account)
            {
            account.Id = _allAccounts.Max(x =>x.Id);
            _allAccounts.Add(account);
            }
        public IEnumerable<Account> GetAll()
        {
            return _allAccounts.ToList();
        }
    }

    public interface IAccountsRepository
    {
        void Add(Account account);
        IEnumerable<Account> GetAll();
    }


}
