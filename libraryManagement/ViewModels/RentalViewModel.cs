using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using libraryManagement.Models;
using libraryManagement.Services;
using SQLite;

namespace libraryManagement.ViewModels
{
    public class RentalViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Rental> _rentals;
        private readonly GenericityService _genericityService;

        public int PageSize { get; set; } = 10;
        private int _currentPage = 1;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PagedRentals));
                    OnPropertyChanged(nameof(TotalPages));
                    OnPropertyChanged(nameof(HasPreviousPage));
                    OnPropertyChanged(nameof(HasNextPage));
                }
            }
        }

        public List<Rental> PagedRentals => _rentals.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        public int TotalPages => (int)Math.Ceiling((double)_rentals.Count / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public RentalViewModel(GenericityService genericityService)
        {
            _genericityService = genericityService;
            _rentals = new ObservableCollection<Rental>();
        }

        public ObservableCollection<Rental> Rentals
        {
            get => _rentals;
            set
            {
                if (_rentals != value)
                {
                    _rentals = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PagedRentals));
                    OnPropertyChanged(nameof(TotalPages));
                    OnPropertyChanged(nameof(HasPreviousPage));
                    OnPropertyChanged(nameof(HasNextPage));
                }
            }
        }

        public void PreviousPage()
        {
            if (HasPreviousPage)
            {
                CurrentPage--;
            }
        }

        public void NextPage()
        {
            if (HasNextPage)
            {
                CurrentPage++;
            }
        }

        public async Task<bool> CheckExist(int id)
        {
            try
            {
                var existingRental = await _genericityService.GetObjects<Rental>();
                return existingRental.Any(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CheckExist Error: {ex.Message}");
                return false;
            }
        }

        public async Task Search(Dictionary<string, string> filters)
        {
            try
            {
                var result = await _genericityService.Search<Rental>(filters);
                Rentals = new ObservableCollection<Rental>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search Error: {ex.Message}");
            }
        }

        public async Task LoadRentalsAsync()
        {
            try
            {
                Console.WriteLine("LoadRentalsAsync: Start loading rentals.");

                var rentals = await _genericityService.LoadAllRentalsWithDetailsAsync();
                Rentals = new ObservableCollection<Rental>(rentals);
                OnPropertyChanged(nameof(PagedRentals));

                Console.WriteLine($"LoadRentalsAsync: Loaded {Rentals.Count} rentals.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadRentalsAsync Error: {ex.Message}");
            }
        }

        public async Task<Rental> LoadRentalWithDetailsAsync(int rentalId)
        {
            var rental = await _genericityService._context._database.Table<Rental>().Where(r => r.Id == rentalId).FirstOrDefaultAsync();

            if (rental != null)
            {
                // Load the associated Student
                rental.Student = await _genericityService._context._database.Table<Student>().Where(s => s.Id == rental.StudentId).FirstOrDefaultAsync();

                // Load the associated RentalBooks
                rental.RentalBooks = await _genericityService._context._database.Table<RentalBooks>().Where(rb => rb.RentalID == rental.Id).ToListAsync();

                // Load each associated Book in RentalBooks
                foreach (var rentalBook in rental.RentalBooks)
                {
                    rentalBook.Book = await _genericityService._context._database.Table<Book>().Where(b => b.Id == rentalBook.BookId).FirstOrDefaultAsync();
                }
            }

            return rental;
        }

        public async Task AddRentalBookAsync(RentalBooks rentalBook)
        {
            try
            {
                await _genericityService.AddItemAsync(rentalBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddRentalBookAsync Error: {ex.Message}");
            }
        }

        public async Task AddRentalAsync(Rental rental)
        {
            try
            {
                // Enable foreign key constraints
                await _genericityService._context._database.ExecuteAsync("PRAGMA foreign_keys = ON;");

                System.Diagnostics.Debug.WriteLine($"Attempting to insert Rental: RentalDate={rental.RentalDate}, ReturnDate={rental.ReturnDate}, StudentId={rental.StudentId}");

                // Save the Rental object first
                await _genericityService._context._database.InsertAsync(rental);

                System.Diagnostics.Debug.WriteLine($"Rental inserted with ID: {rental.Id}");

                foreach (var rentalBook in rental.RentalBooks)
                {
                    // Ensure that the RentalID is correctly set before processing
                    rentalBook.RentalID = rental.Id;

                    System.Diagnostics.Debug.WriteLine($"Attempting to insert RentalBook: BookId={rentalBook.BookId}, Quantity={rentalBook.Quantity}, RentalID={rentalBook.RentalID}");

                    // Fetch the latest Book data from the database to ensure accuracy
                    var book = await _genericityService._context._database.FindAsync<Book>(rentalBook.BookId);
                    if (book == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Book with ID {rentalBook.BookId} not found.");
                        continue;
                    }

                    // Log the current stock before updating
                    System.Diagnostics.Debug.WriteLine($"Before Stock Update: BookId={book.Id}, Current Stock={book.Stock}, Quantity to Deduct={rentalBook.Quantity}");

                    // Ensure that the stock update only happens once per rental book
                    if (rentalBook.RentalID == rental.Id)
                    {
                        // Insert RentalBook into the database
                        await _genericityService._context._database.InsertAsync(rentalBook);

                        // Update the book stock
                        book.Stock -= rentalBook.Quantity;
                        await _genericityService._context._database.UpdateAsync(book);

                        System.Diagnostics.Debug.WriteLine($"RentalBook inserted: BookId={book.Id}, Remaining Stock={book.Stock}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"RentalBook skipped: RentalID mismatch or double processing detected.");
                    }
                }


            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQLiteException occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General Exception occurred: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            try
            {
                await _genericityService.UpdateItemAsync(rental);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateRentalAsync Error: {ex.Message}");
            }
        }

        public async Task DeleteRentalAsync(Rental rental)
        {
            try
            {
                await _genericityService.DeleteItemAsync(rental);
                Rentals.Remove(rental);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteRentalAsync Error: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
