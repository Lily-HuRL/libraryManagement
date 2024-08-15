using libraryManagement.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using libraryManagement.Models;

namespace libraryManagement.Services
{
    public class GenericityService
    {
        public readonly AppDbContext _context;

        public GenericityService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task EnsureTableExists<T>() where T : class, new()
        {
            try
            {
                await _context._database.CreateTableAsync<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EnsureTableExists<{typeof(T).Name}> Error: {ex.Message}");
            }
        }

        public async Task<List<T>> GetObjects<T>(params Expression<Func<T, object>>[] includes) where T : class, new()
        {
            try
            {
                await EnsureTableExists<T>();  // Ensure the table exists before fetching data
                return await _context._database.Table<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetObjects<{typeof(T).Name}> Error: {ex.Message}");
                throw;
            }
        }

        public async Task AddItemAsync<T>(T item) where T : class, new()
        {
            try
            {
                await EnsureTableExists<T>();  // Ensure the table exists before adding data
                await _context._database.InsertAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddItemAsync<{typeof(T).Name}> Error: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateItemAsync<T>(T item) where T : class, new()
        {
            try
            {
                await EnsureTableExists<T>();  // Ensure the table exists before updating data
                await _context._database.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateItemAsync<{typeof(T).Name}> Error: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteItemAsync<T>(T item) where T : class, new()
        {
            try
            {
                await EnsureTableExists<T>();  // Ensure the table exists before deleting data
                await _context._database.DeleteAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteItemAsync<{typeof(T).Name}> Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<T>> Search<T>(Dictionary<string, string> filters) where T : class, new()
        {
            var query = _context._database.Table<T>();

            foreach (var filter in filters)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(parameter, filter.Key);
                var constant = Expression.Constant(filter.Value);
                var equality = Expression.Equal(property, constant);

                var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
                query = query.Where(lambda);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Rental>> LoadAllRentalsWithDetailsAsync()
        {
            var rentals = await _context._database.Table<Rental>().ToListAsync();

            foreach (var rental in rentals)
            {
                // Load the associated Student
                rental.Student = await _context._database.Table<Student>().Where(s => s.Id == rental.StudentId).FirstOrDefaultAsync();

                // Load the associated RentalBooks
                rental.RentalBooks = await _context._database.Table<RentalBooks>().Where(rb => rb.RentalID == rental.Id).ToListAsync();

                // Load each associated Book in RentalBooks
                foreach (var rentalBook in rental.RentalBooks)
                {
                    rentalBook.Book = await _context._database.Table<Book>().Where(b => b.Id == rentalBook.BookId).FirstOrDefaultAsync();
                }
            }

            return rentals;
        }

    }

}
