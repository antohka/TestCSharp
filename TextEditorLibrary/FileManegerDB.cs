using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorLibrary
{
    public class FileManegerDB: FileManeger, IFileManeger
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding("utf-8");

        public override string GetContent(string fileName)
        {
            return GetContent(fileName, _defaultEncoding);
        }

        public override string GetContent(string fileName, Encoding encoding)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM files WHERE fileName = '{fileName}'";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                string str = "";
                while (reader.Read())
                {
                    str = encoding.GetString((byte[])reader.GetValue(3));
                }

                return str;
            }
        }

        public override void SaveContent(string content, string fileName)
        {
            SaveContent(content, fileName, _defaultEncoding);
        }

        public override void SaveContent(string content, string fileName, Encoding encoding)
        {
            if (fileName == "")
            {
                return;
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            }
        }
    }
}

