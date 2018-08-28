using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Repositories
{
    public class BankSitesRepository : IBankSitesRepository
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

    public interface IBankSitesRepository
    {
        void Add(BankSite banksite);
        IEnumerable<BankSite> GetAll();
    }
}
