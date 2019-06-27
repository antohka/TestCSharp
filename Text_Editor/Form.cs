using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class Form : System.Windows.Forms.Form, IForm
    {
        private object locker = new object();

        public Form()
        {
            InitializeComponent();

            openFile.Click += new EventHandler(OpenFileClick);
            saveFile.Click += new EventHandler(SaveFileClick);
            saveFileDB.Click += new EventHandler(SaveFileDBClick);
            selectFileDB.Click += new EventHandler(GetFileFromDB);
            fieldText.TextChanged += new EventHandler(ChangeFileClick);
            clearAllClick.Click += new EventHandler(ClearAllClick);
            fontSize.ValueChanged += SetValueChanged;
        }

        public object GetLocker
        {
            get
            {
                return locker;
            }
        }
        public string GetFileDB
        {
            get
            {
                return fileNameDB.Text;
            }
            set
            {
                fieldText.Text = value;
            }
        }

        public string GetDBFile
        {
            get
            {
                return fileNameFromDB.Text;
            }
        }

        public string SelectFile
        {
            get; set;
        }

        public string FilePath
        {
            get
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SelectFile = dlg.FileName;
                    return SelectFile;
                }
                else
                {
                    return "";
                }
            }
        }

        public string Content
        {
            get {
                return fieldText.Text;                            
            }
            set { fieldText.Text = value; }
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler FileSaveDBClick;
        public event EventHandler ContentChanged;
        public event EventHandler GetFileDBClick;

        private void OpenFileClick(object sender, EventArgs e)
        {
            FileOpenClick?.Invoke(this, EventArgs.Empty);
        }

        private void SaveFileClick(object sender, EventArgs e)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void SaveFileDBClick(object sender, EventArgs e)
        {
            FileSaveDBClick?.Invoke(this, EventArgs.Empty);
        }

        private void GetFileFromDB(object sender, EventArgs e)
        {
            GetFileDBClick?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeFileClick(object sender, EventArgs e)
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetValueChanged(object sender, EventArgs e)
        {
            fieldText.Font = new Font("Verdana", (float)fontSize.Value);
        }

        private void ClearAllClick(object sender, EventArgs e)
        {
            fieldText.Text = "";
        }
    }
}
