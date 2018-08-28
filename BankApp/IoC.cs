﻿using BankApp.Commands;
using BankApp.Factories;
using BankApp.Helpers;
using BankApp.Repositories;
using BankApp.Services;
using Unity;

namespace BankApp
{
    public static class IoC
    {
        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                    _container = GetIoCContainer();
                return _container;
            }
        }

        private static IUnityContainer _container;

        private static IUnityContainer GetIoCContainer()
        {
            var iocContainer = new UnityContainer();
            iocContainer.RegisterType<IAccountsFactory, AccountsFactory>();
            iocContainer.RegisterType<IBankSitesFactory, BankSitesFactory>();
            iocContainer.RegisterType<IBankTransfersFactory, BankTransfersFactory>();

            iocContainer.RegisterType<IDisplayHelper, DisplayHelper>();
            iocContainer.RegisterType<IConsoleHelper, ConsoleHelper>();
            iocContainer.RegisterType<IInputHelper, InputHelper>();

            iocContainer.RegisterType<IExcelService, ExcelService>();

            iocContainer.RegisterType<IAccountsRepository, AccountsRepository>();
            iocContainer.RegisterType<IBankSitesRepository, BankSitesRepository>();
            iocContainer.RegisterType<IBankTransfersRepository, BankTransfersRepository>();

            iocContainer.RegisterType<ICreateEntityCommand, CreateEntityCommand>();
            iocContainer.RegisterType<IDisplayEntitiesCommand, DisplayEntitiesCommand>();
            iocContainer.RegisterType<IGetExcelTemplateCommand, GetExcelTemplateCommand>();
            iocContainer.RegisterType<IGetDataFromExcelTemplateCommand, GetDataFromExcelTemplateCommand>();
            return iocContainer;
        }
    }
}
