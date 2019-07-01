using System;
using System.IO;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TextEditorLibrary
{  
    public class FileManeger : IFileManeger
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        } 

        private readonly Encoding _defaultEncoding = Encoding.GetEncoding("utf-8");

        public virtual string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }

        public virtual string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public virtual void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }

        public virtual void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
    }
}
