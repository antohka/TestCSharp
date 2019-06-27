using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditorLibrary;

namespace Text_Editor
{
    class FormPresenter
    {       
        private readonly IForm _view;
        private readonly IFileManeger _maneger;
        private readonly IMessageService _messageService;
        private string _currentFilePath;

        public FormPresenter(IForm view, IFileManeger maneger, IMessageService messageService)
        {
            _view = view;
            _maneger = maneger;
            _messageService = messageService;

            _view.ContentChanged += new EventHandler(_ViewContentChanged);
            _view.FileOpenClick += new EventHandler(_ViewFileOpenClick);
            _view.FileSaveClick += new EventHandler(_ViewFileSaveClick);
            _view.FileSaveDBClick += new EventHandler(_ViewFileSaveDBClick);
            _view.GetFileDBClick += new EventHandler(_ViewFileGetDBClick);
        }

        public void _ViewContentChanged(object sender, EventArgs e)
        {

        }
        public async void _ViewFileGetDBClick(object sender, EventArgs e)
        {
            try
            {
                string fileName = _view.GetDBFile;
                string content = "";

                await Task.Factory.StartNew(() =>
                        content = _maneger.GetContentDB(fileName),
                         TaskCreationOptions.LongRunning);
                _view.Content = content;

                if (content == "")
                {
                    _messageService.ShowExclamation("file not exists or empty");
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// select file from a file system
        /// </summary>
        public void _ViewFileOpenClick(object sender, EventArgs e) 
        {
            try
            {
                string filePath = _view.FilePath;
                bool isExistst = _maneger.IsExist(filePath);

                if (!isExistst)
                {
                    _messageService.ShowExclamation("The file is not exist");
                    return;
                }

                _currentFilePath = filePath;

                string content = _maneger.GetContent(filePath);

                _view.Content = content;

            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// save a file
        /// </summary>
 
        public void _ViewFileSaveClick(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                if(dlg.ShowDialog() == DialogResult.OK && dlg.FileName.Length > 0)
                {
                    using (StreamWriter sw = new StreamWriter(dlg.FileName, true))
                    {
                        sw.WriteLine(_view.Content);
                        sw.Close();
                        _messageService.ShowMessage("Save of the file is success");
                    }
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// save a file to DB
        /// </summary>
        public async void _ViewFileSaveDBClick(object sender, EventArgs e)
        {
            try
            {
                string text = _view.Content;
                string name = _view.GetFileDB;
                string result = await Task.Factory.StartNew<string>(
                                           () => _maneger.SaveContentDB(text, name),
                                           TaskCreationOptions.LongRunning);
                if (result != "")
                    _messageService.ShowMessage(result);
                else
                    _messageService.ShowError("Enter a file name please");
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
    }
}
