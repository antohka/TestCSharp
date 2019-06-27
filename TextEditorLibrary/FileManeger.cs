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
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        private readonly Encoding _defaultEncoding = Encoding.GetEncoding("utf-8");

        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }

        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }

        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public string SaveContentDB(string content, string fileName)
        {
            if (fileName == "")
            {
                return fileName;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"SELECT Count(*) FROM files WHERE fileName = '{fileName}'";
                SqlCommand isExist = new SqlCommand(sql, connection);
                object count = isExist.ExecuteScalar();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                if ((int)count == 0)
                {
                    command.CommandText = @"INSERT INTO files VALUES (@fileName, @title, @contentData)";
                }
                else
                {
                    command.CommandText = @"UPDATE files SET contentData = @contentData";
                }
                   
                command.Parameters.Add("@fileName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@contentData", SqlDbType.VarBinary, 1000000);

                string title = $"Успешно сохранен {DateTime.Now}";
              
                byte[] contentData;

                using (System.IO.FileStream fs = new System.IO.FileStream(fileName, FileMode.OpenOrCreate))
                {
                    contentData = new byte[fs.Length];
                    contentData = Encoding.UTF8.GetBytes(content);
                    fs.Write(contentData, 0, contentData.Length);
                }

                command.Parameters["@fileName"].Value = fileName;
                command.Parameters["@title"].Value = title;
                command.Parameters["@contentData"].Value = contentData;
                command.ExecuteNonQuery();
                return "save success";              
            }
        }

        public string GetContentDB(string fileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM files WHERE fileName = '{fileName}'";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                string str = "";
                while (reader.Read())
                {
                    str = Encoding.UTF8.GetString((byte[])reader.GetValue(3));
                }

                return str;
            }
        }

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
    }
}
