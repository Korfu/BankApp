using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IBankTransferRepository
    {
        void Add(BankTransfer bankTransfer);
        IEnumerable<BankTransfer> GetAll();
    }

    public class BankTransferRepository : IBankTransferRepository
    {
        private static List<BankTransfer> _allBankTransfers = new List<BankTransfer>();

        public void Add(BankTransfer bankTransfer)
        {
            _allBankTransfers.Add(bankTransfer);
        }

        public IEnumerable<BankTransfer> GetAll()
        {
            return _allBankTransfers;
        }
    }

}
