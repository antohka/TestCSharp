using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditorLibrary;

namespace Text_Editor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();
            MessageService service = new MessageService();
            FileManeger maneger = new FileManeger();
            FileManegerDB manegerDB = new FileManegerDB();

            FormPresenter presenter = new FormPresenter(form, maneger, manegerDB, service);

            Application.Run(form);
        }
    }
}
