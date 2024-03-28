using Microsoft.EntityFrameworkCore;
using WeatherForecastUI.Components;
using WeatherForecastUI.Context;
using WeatherForecastUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowBlazorApp",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:7162") // Adjust the URL to match your Blazor app URL
//                .AllowAnyMethod()
//                .AllowAnyHeader();
//        });
//});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<UserService>();

var app = builder.Build();

//app.UseCors("AllowBlazorApp");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
