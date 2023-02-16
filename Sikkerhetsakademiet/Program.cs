using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sikkerhetsakademiet.Configuration;
using Sikkerhetsakademiet.Persistence;

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FormDbContext>(opt => opt.UseSqlite(connection));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

var app = builder.Build();
app.SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage(); // noe må gjøres

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpReponseHeaders();

app.Run();
