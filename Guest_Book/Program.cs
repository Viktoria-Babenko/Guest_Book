using Guest_Book.Models;
using Guest_Book.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ReviewsContext>(options => options.UseSqlServer(connection));

builder.Services.AddDistributedMemoryCache();// ��������� IDistributedMemoryCache

builder.Services.AddScoped<IRepository, ReviewsRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������
app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
