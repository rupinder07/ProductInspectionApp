using ProductInspection.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.repository
{
    public class BaseRepository<T> where T : class, new()
    {

        private SQLiteAsyncConnection database = RepositoryHelper.Connection;

        public Task<List<T>> GetItemsAsync()
        {
            AsyncTableQuery<T> AsQueryable = database.Table<T>();
            return AsQueryable.ToListAsync();
        }
        

        public void SaveItemAsync(T item)
        {
            try {
                database.InsertAsync(item);
            }
            catch(Exception e)
            {
                Console.Out.Write("Error inserting item " + e);
            }
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return database.DeleteAsync(item);

        }

        internal void DeleteItemById(string tableName, int id)
        {
            SQLiteCommand command = database.GetConnection().CreateCommand("Delete from " + tableName + " where id = " + id);
            command.ExecuteNonQuery();
        }

        public Task<int> UpdateItemAsync(T item)
        {
            return database.UpdateAsync(item);
        }

        internal void SaveAllItemsAsync(List<T> products)
        {
            database.InsertAllAsync(products);
        }

        internal Task<List<T>> GetItemById(string tablename, int productId)
        {
            return database.QueryAsync<T>("select * from "+tablename+" where id = ?", productId);
        }

        internal void DeleteAllItems(string tableName)
        {
            SQLiteCommand command = database.GetConnection().CreateCommand("Delete from " + tableName);
            command.ExecuteNonQuery();
        }
    }
}
