using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovies.Data;
using RazorPageMovies.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPageMoviesContext1>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMoviesContext1") ?? throw new InvalidOperationException("Connection string 'RazorPageMoviesContext1' not found.")));
//builder.Services.AddDbContext<RazorPageMoviesContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMoviesContext") ?? throw new InvalidOperationException("Connection string 'RazorPageMoviesContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initalizate(services);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
