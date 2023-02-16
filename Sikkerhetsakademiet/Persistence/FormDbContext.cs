using Microsoft.EntityFrameworkCore;
using Sikkerhetsakademiet.Models;

namespace Sikkerhetsakademiet.Persistence
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options)
            : base(options) { }

        public DbSet<Form> Forms { get; set; }
    };
}