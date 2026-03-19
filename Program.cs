using CO5078_GuestHouse_Dynamic.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();

// Connect to SQL Server database
builder.Services.AddDbContext<GuestHouseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestHouseConnection")));

// Enable session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapRazorPages();

app.Run();