using Microsoft.EntityFrameworkCore;

namespace Bryan_Rodriguez_PC3.Models
{
    public class BuscoContext : DbContext
    {
        public DbSet<Producto> Productos{get; set;}
        public DbSet<Categoria> Categorias{get; set;}
        
        public BuscoContext(DbContextOptions dbo): base(dbo){

        }
    }
}