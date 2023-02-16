using Sikkerhetsakademiet.Models;
using Sikkerhetsakademiet.Persistence;

namespace Sikkerhetsakademiet.Configuration
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
             
            var context = services.GetRequiredService<FormDbContext>(); 
            context.Database.EnsureCreated();
            context.Forms.Add(new Form { Id = 1, Name = "Ola Nordmann", Message = "Jeg liker sikre webløsninger" });
            context.SaveChanges();
        }
    }
}