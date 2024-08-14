using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using libraryManagement.Models;
using libraryManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace libraryManagement.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books;
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
                    OnPropertyChanged(nameof(PagedBooks));
                    OnPropertyChanged(nameof(TotalPages));
                    OnPropertyChanged(nameof(HasPreviousPage));
                    OnPropertyChanged(nameof(HasNextPage));
                }
            }
        }

        public List<Book> PagedBooks => _books.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        public int TotalPages => (int)Math.Ceiling((double)_books.Count / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public BookViewModel(GenericityService genericityService)
        {
            _genericityService = genericityService;
            _books = new ObservableCollection<Book>();
        }

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                if (_books != value)
                {
                    _books = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PagedBooks));
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

        public async Task LoadBooksAsync()
        {
            var books = await _genericityService.GetObjects<Book>();
            Books = new ObservableCollection<Book>(books);
        }

        public async Task<Boolean> CheckExist(string isbn)
        {
            var existingBook = await _genericityService._context.Books
                                     .FirstOrDefaultAsync(b=>b.ISBN == isbn);
            if (existingBook != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Search(Dictionary<string, string> filters)
        {
            var result = await _genericityService.Search<Book>(filters);
            Books = new ObservableCollection<Book>(result);
        }

        public async Task AddBookAsync(Book book)
        {
            await _genericityService.AddItemAsync(book);
            Books.Add(book);
            OnPropertyChanged(nameof(PagedBooks));
            OnPropertyChanged(nameof(TotalPages));
            OnPropertyChanged(nameof(HasPreviousPage));
            OnPropertyChanged(nameof(HasNextPage));
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _genericityService.UpdateItemAsync(book);
            OnPropertyChanged(nameof(PagedBooks));
        }

        public async Task DeleteBookAsync(Book book)
        {
            await _genericityService.DeleteItemAsync(book);
            Books.Remove(book);
            OnPropertyChanged(nameof(PagedBooks));
            OnPropertyChanged(nameof(TotalPages));
            OnPropertyChanged(nameof(HasPreviousPage));
            OnPropertyChanged(nameof(HasNextPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

