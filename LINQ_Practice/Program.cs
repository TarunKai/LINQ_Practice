using LINQ_Practice.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("ctorStr");

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add connection string to services
builder.Services.AddDbContext<DB2023_LINQContext>(options =>
{
    options.UseSqlServer(connStr);
});

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
    pattern: "{controller=LINQPractices}/{action=getRecords}/{id?}");

app.Run();
