using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Marka> Marki { get; set; }
        public DbSet<Model> Modele { get; set; }
        
    }
}
