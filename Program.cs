using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();

// 🛠️ Listen on 0.0.0.0:80 (important for Docker/Kubernetes)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
});

var app = builder.Build();

// Serve static files (i.e., files in wwwroot)
app.UseStaticFiles();

// Enable Routing
app.UseRouting();

// Map Controllers (for API routes)
app.MapControllers();

// Start the application
app.Run();

