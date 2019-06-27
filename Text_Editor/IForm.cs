using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    interface IForm
    {
        object GetLocker { get; }
        string FilePath { get; }
        string GetFileDB { get; set; }
        string GetDBFile { get;}
        string Content { get; set; }
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler FileSaveDBClick;
        event EventHandler GetFileDBClick;
        event EventHandler ContentChanged;
    }
}
