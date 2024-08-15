using SQLite;
using libraryManagement.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace libraryManagement.Data
{
    public class AppDbContext
    {
        public readonly SQLiteAsyncConnection _database;

        public AppDbContext(SQLiteAsyncConnection database)
        {
            _database = database;
            Initialize(); // Synchronous table creation
        }

        private void Initialize()
        {
            _database.CreateTableAsync<Book>().Wait();
            _database.CreateTableAsync<Student>().Wait();
            _database.CreateTableAsync<Rental>().Wait();
            _database.CreateTableAsync<RentalBooks>().Wait();
        }

        public SQLiteAsyncConnection Database => _database;

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }

        public Task<Book> GetBookAsync(int id)
        {
            return _database.Table<Book>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
            {
                return _database.UpdateAsync(book);
            }
            else
            {
                return _database.InsertAsync(book);
            }
        }

        public Task<int> DeleteBookAsync(Book book)
        {
            return _database.DeleteAsync(book);
        }

        // Implement similar methods for Student, Rental, RentalBooks
    }
}
