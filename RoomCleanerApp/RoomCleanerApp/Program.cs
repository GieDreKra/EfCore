using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Data;
using RoomCleanerApp.Repositories;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=T470S;Database=Hotels;Trusted_Connection=True;";
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer(connectionString));

builder.Services.AddTransient<HotelRepository>();

//var startup = new Startup(builder.Configuration);

//var defaultConnection = System.Configuration.GetConnectionString("DefaultConnection");
//  services.AddDbContext<DataContext>(d => d.UseSqlServer(defaultConnection));
// services.AddTransient<TodoRepository>();
// services.AddTransient<CategoryRepository>();
//  services.AddTransient<TagRepository>();
//  services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
