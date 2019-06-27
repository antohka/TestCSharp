using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string excl);
        void ShowError(string error);
    }
}
