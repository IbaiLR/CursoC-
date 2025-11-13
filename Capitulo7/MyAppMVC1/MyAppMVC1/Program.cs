var builder = WebApplication.CreateBuilder(args);

// 1. Servicios
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// 2. Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ⬅️ MUY IMPORTANTE: Necesario para cookies y sesiones
app.UseStaticFiles();

app.UseRouting();

// ⬅️ Sesiones SIEMPRE después de UseRouting y antes de Auth
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
