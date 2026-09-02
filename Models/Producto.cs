using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProductosPedroMiranda.Models
{
    public class Producto : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}
