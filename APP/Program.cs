using Serilog;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura Serilog para guardar los logs
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Usa Serilog para los logs
//builder.Host.UseSerilog();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ApiService>();

var app = builder.Build();

// Configura la tubería de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
