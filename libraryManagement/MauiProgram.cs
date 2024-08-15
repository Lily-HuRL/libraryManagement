using Microsoft.Extensions.Logging;
using libraryManagement.Data;
using libraryManagement.ViewModels;
using libraryManagement.Services;
using libraryManagement.Utils;
using SQLite;
using libraryManagement.Models;
using Microsoft.Extensions.DependencyInjection;


namespace libraryManagement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // Register services
            builder.Services.AddScoped<MessageHelper>();

            // Setup SQLite database path

            string dbPath = "C:\\SAIT\\SD program\\2nd Semester\\Object-Oriented Programming 2\\project\\final\\libraryManagement\\libraryManagement\\library.db";

            // Register SQLite connection as a singleton
            builder.Services.AddSingleton<SQLiteAsyncConnection>(s =>
            {
                var connection = new SQLiteAsyncConnection(dbPath);

                // Enable foreign key constraints
                connection.ExecuteAsync("PRAGMA foreign_keys = ON;").Wait();

                connection.CreateTableAsync<Book>().Wait();
                connection.CreateTableAsync<Student>().Wait();
                connection.CreateTableAsync<Rental>().Wait();
                connection.CreateTableAsync<RentalBooks>().Wait();
                return connection;
            });

            // Register AppDbContext
            builder.Services.AddSingleton<AppDbContext>(s =>
            {
                var connection = s.GetRequiredService<SQLiteAsyncConnection>();
                return new AppDbContext(connection);
            });


            // Register the GenericityService and ViewModels with the SQLite connection
            builder.Services.AddTransient<GenericityService>();
            builder.Services.AddTransient<BookViewModel>();
            builder.Services.AddTransient<RentalViewModel>();
            builder.Services.AddTransient<StudentViewModel>();
            builder.Services.AddSingleton<AuthService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
