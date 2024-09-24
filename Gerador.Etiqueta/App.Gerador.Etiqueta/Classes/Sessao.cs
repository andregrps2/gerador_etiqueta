using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Classes
{
    public sealed class Sessao : IDisposable
    {
        public static string DbFile { get; set; } = Environment.CurrentDirectory + @"\Dados\BaseEtiqueta.db";

        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }

        public Sessao()
        {
            try
            {
                Connection = new SQLiteConnection($"Data Source={DbFile};Version=3;New=False;Compress=True;");
                CriarArquivoDb();
            }
            catch
            {
                throw;
            }
        }

        public void CriarArquivoDb()
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(DbFile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(DbFile));

                if (!File.Exists(DbFile))
                {
                    StreamWriter file = new StreamWriter(DbFile, true, Encoding.Default);
                    file.Dispose();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Dispose() => Connection?.Dispose();
    }
}