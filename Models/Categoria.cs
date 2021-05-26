using System.Collections.Generic;

namespace Bryan_Rodriguez_PC3.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Producto{get; set;}

    }
}