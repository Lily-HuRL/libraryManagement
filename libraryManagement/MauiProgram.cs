using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using libraryManagement.Data;
using libraryManagement.ViewModels;
using libraryManagement.Services;
using libraryManagement.Utils;

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

            builder.Services.AddScoped<MessageHelper>();
            string connectionString = "Server=localhost;Database=library;User=root;Password=123456;";

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 0, 0)),
                mysqlOptions => mysqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null))
        );
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
