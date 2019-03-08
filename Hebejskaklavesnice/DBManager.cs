using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Hebejskaklavesnice
{
    public class DBManager
    {
        private SQLiteConnection sqliteConn;

        public DBManager()
        {
            sqliteConn = new SQLiteConnection(@"Data Source = C:\Users\kouck\Source\Repos\danielkoucky\hebrew-keyboard\sqlite.db; Version = 3");
            sqliteConn.Open();
        }


        public string GetColumn(string sql)
        {
            if (sqliteConn.State != System.Data.ConnectionState.Open)
                sqliteConn.Open();

            return  sqliteConn.Query<string>(sql).FirstOrDefault();
        }
    }
}
