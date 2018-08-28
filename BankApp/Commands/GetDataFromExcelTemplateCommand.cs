using BankApp.Helpers;
using BankApp.Repositories;
using BankApp.Services;
using System;
using System.Windows.Forms;
using BankApp.Models;

namespace BankApp.Commands
{
    class GetDataFromExcelTemplateCommand : IGetDataFromExcelTemplateCommand
    {
        private readonly IExcelService _excelService;
        private readonly IAccountsRepository _accountsRepository;
        private readonly IBankTransfersRepository _bankTransfersRepository;
        private readonly IBankSitesRepository _bankSitesRepository;
        private readonly IConsoleHelper _consoleHelper;

        public GetDataFromExcelTemplateCommand(
            IExcelService excelService,
            IAccountsRepository accountsRepository,
            IBankTransfersRepository bankTransfersRepository,
            IBankSitesRepository bankSitesRepository,
            IConsoleHelper consoleHelper)
        {
            _excelService = excelService;
            _accountsRepository = accountsRepository;
            _bankTransfersRepository = bankTransfersRepository;
            _bankSitesRepository = bankSitesRepository;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Getting data from excel template...");
            _consoleHelper.WriteLine("1) Account");
            _consoleHelper.WriteLine("2) Bank Transfer");
            _consoleHelper.WriteLine("3) Bank Site");
            var chosenOption = _consoleHelper.ReadKey();
            string path = "";
            switch (chosenOption)
            {
                case ConsoleKey.D1:
                    path = GetFilePath();
                    ImportAccounts(path);
                    break;
                case ConsoleKey.D2:
                    path = GetFilePath();
                    ImportBankTransfers(path);
                    break;
                case ConsoleKey.D3:
                    path = GetFilePath();
                    ImportBankSites(path);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, try again");
                    Execute();
               break;
            }
        }

        private void ImportBankSites(string path)
        {
            var itemList = _excelService.GetItemsFromTemplate<BankSite>(path);
            foreach (var item in itemList)
            {
                _bankSitesRepository.Add(item);
            }
        }

        private void ImportBankTransfers(string path)
        {
            var itemList = _excelService.GetItemsFromTemplate<BankTransfer>(path);
            foreach (var item in itemList)
            {
                _bankTransfersRepository.Add(item);
            }
        }

        private void ImportAccounts(string path)
        {
            var itemList = _excelService.GetItemsFromTemplate<Account>(path);
            foreach (var item in itemList)
            {
                _accountsRepository.Add(item);
            }
        }

        [STAThread]
        private string GetFilePath()
        {
            string fileName = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Template file";
            fd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            fd.DefaultExt = "xlsx";
            fd.AddExtension = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fileName = fd.FileName;
            }
            return fileName;
        }
    }

    internal interface IGetDataFromExcelTemplateCommand : ICommand
    {
    }
}
