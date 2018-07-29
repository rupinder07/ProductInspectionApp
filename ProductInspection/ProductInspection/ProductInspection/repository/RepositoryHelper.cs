using ProductInspection.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInspection.repository
{
    class RepositoryHelper
    {

        public static SQLiteAsyncConnection Connection;

        public static void InitializeConnection(string dbPath)
        {
            Connection = new SQLiteAsyncConnection(dbPath);
            //Add all the tables here
            Connection.CreateTablesAsync<User, Inspection, Product>();
        }
    }
}
