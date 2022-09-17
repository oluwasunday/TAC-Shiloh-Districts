using System;
using TACShilohDistricts;
using TACShilohDistricts.Extensions;
using TACShilohDistricts.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

//using (var scope = builder.Services.CreateScope())

// Add services to the container.
builder.Services.AddControllersWithViews();

var startup = new Startup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TACShilohContext>();
    // use context
    startup.Configure(app, dbContext);
}


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

string? port = Environment.GetEnvironmentVariable("PORT"); if (!string.IsNullOrWhiteSpace(port)) { app.Urls.Add("http://*:" + port); }
app.Run();
