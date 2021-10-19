using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class PruebaContext : DbContext
    {

        public PruebaContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<History> historiales{get; set;}
        
    }
}