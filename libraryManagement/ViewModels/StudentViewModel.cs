using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using libraryManagement.Models;
using libraryManagement.Services;

namespace libraryManagement.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
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
                }
            }
        }

        public StudentViewModel(GenericityService genericityService)
        {
            _genericityService = genericityService;
            _students = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                if (_students != value)
                {
                    _students = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task<bool> CheckExist(int id)
        {
            try
            {
                var existingStudent = await _genericityService.GetObjects<Student>();
                return existingStudent.Any(s => s.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CheckExist Error: {ex.Message}");
                return false;
            }
        }

        public async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _genericityService.GetObjects<Student>();
                Students = new ObservableCollection<Student>(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadStudentsAsync Error: {ex.Message}");
            }
        }

        public async Task Search(Dictionary<string, string> filters)
        {
            try
            {
                var result = await _genericityService.Search<Student>(filters);
                Students = new ObservableCollection<Student>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search Error: {ex.Message}");
            }
        }

        public async Task AddStudentAsync(Student student)
        {
            try
            {
                await _genericityService.AddItemAsync(student);
                Students.Add(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddStudentAsync Error: {ex.Message}");
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                await _genericityService.UpdateItemAsync(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateStudentAsync Error: {ex.Message}");
            }
        }

        public async Task DeleteStudentAsync(Student student)
        {
            try
            {
                await _genericityService.DeleteItemAsync(student);
                Students.Remove(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteStudentAsync Error: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
