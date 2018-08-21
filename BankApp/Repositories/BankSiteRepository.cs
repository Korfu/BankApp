using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IBankSiteRepository
    {
        void Add(BankSite banksite);
        IEnumerable<BankSite> GetAll();
    }

    public class BankSiteRepository : IBankSiteRepository
    {
        private static List<BankSite> _allBankSites = new List<BankSite>();

        public void Add(BankSite banksite)
        {
            _allBankSites.Add(banksite);
        }
        public IEnumerable<BankSite> GetAll()
        {
            return _allBankSites;
        }
    }
}
