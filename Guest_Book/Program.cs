using Guest_Book.Models;
using Guest_Book.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ReviewsContext>(options => options.UseSqlServer(connection));

builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache

builder.Services.AddScoped<IRepository, ReviewsRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseSession();   // Добавляем middleware-компонент для работы с сессиями
app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
