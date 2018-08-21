using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Repositories
{
    public  interface IAccountRepository
    {
        void Add(Account account);
        IEnumerable<Account> GetAll();
    }

    public class AccountRepository : IAccountRepository
    {
        private static List<Account> _allAccounts = new List<Account>();

        public void Add (Account account)
            {
            account.Id = _allAccounts.Max(x =>x.Id);
            _allAccounts.Add(account);
            }
        public IEnumerable<Account> GetAll()
        {
            return _allAccounts;
        }
    }


    
}
