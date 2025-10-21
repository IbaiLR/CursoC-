using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Conexión MySQL
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(connStr));

// 🔹 Razor Pages
builder.Services.AddRazorPages();

// 🔹 Sesiones
builder.Services.AddDistributedMemoryCache(); // almacenamiento en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🔹 Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🔹 Activar sesiones ANTES de MapRazorPages
app.UseSession();

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
