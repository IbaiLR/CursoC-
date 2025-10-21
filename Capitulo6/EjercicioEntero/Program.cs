using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// 👇 Recuperamos la cadena desde appsettings.json
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar como servicio (para inyectarla donde la necesites)
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(connStr));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.MapRazorPages()
   .WithStaticAssets();

app.Run();
