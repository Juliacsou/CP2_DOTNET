using Microsoft.EntityFrameworkCore;
using CP2_DOTNET.Entities;

namespace CP2_DOTNET.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}