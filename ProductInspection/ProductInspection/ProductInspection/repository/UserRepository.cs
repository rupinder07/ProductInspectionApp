using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductInspection.model;
using SQLite;

namespace ProductInspection.repository
{
    public class UserRepository
    {
        readonly SQLiteAsyncConnection database;
        public UserRepository(string dbPath){
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }



        public Task<List<User>> GetItemsAsync()

        {

            return database.Table<User>().ToListAsync();

        }




        public Task<int> SaveItemAsync(User item)

        {

            if (item.ID != 0){

                return database.UpdateAsync(item);
  
            }
            return database.InsertAsync(item);
        }



        public Task<int> DeleteItemAsync(User item)

        {

            return database.DeleteAsync(item);

        }

    }
}
