using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    public class InputHelper : IInputHelper
    {
        private readonly IConsoleHelper _consoleHelper;

        public InputHelper(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public DateTime GetDateTimeFromConsole(string message)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimalFromConsole(string message)
        {
            throw new NotImplementedException();
        }

        public int GetIntFromConsole(string message)
        {
            _consoleHelper.WriteLine(message);
            var input = _consoleHelper.ReadLine();

            if (int.TryParse(input,out int result))
            {
                return result;
            }
            else
            {
                return GetIntFromConsole(message);
            }
        }
    }

    public interface IInputHelper
    {
        int GetIntFromConsole(string message);

        decimal GetDecimalFromConsole(string message);

        DateTime GetDateTimeFromConsole(string message);
    }
}
