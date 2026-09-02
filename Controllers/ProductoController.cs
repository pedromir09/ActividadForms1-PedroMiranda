using GestorProductosPedroMiranda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProductosPedroMiranda.Controllers
{
    public class ProductoController
    {
        private List<Producto> _productos = new List<Producto>();
        private int _siguienteId = 1;

        public void Agregar(string nombre, int stock, decimal precio)
        {
            var producto = new Producto
            {
                Id = _siguienteId++,
                Nombre = nombre,
                Stock = stock,
                Precio = precio
            };
            _productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }

        //elimina de la lista el producto que tenga ese id
        //el RemoveAll borra todos los elementos que cumplan la condicion
        public void Eliminar(int id)
        {
            _productos.RemoveAll(p => p.Id == id);
        }

        //busca el producto por id dentro de la lista y actualiza sus datos con los valores modificados
        public void Modificar(Producto modificado)
        {
            var p = _productos.Find(x => x.Id == modificado.Id);
            if (p == null) return; // por si no lo encuentra

            p.Nombre = modificado.Nombre;
            p.Stock = modificado.Stock;
            p.Precio = modificado.Precio;
        }

        //devuelve los productos donde el nombre contenga el texto buscado - si el texto esta vacio, devuelve todos
        public List<Producto> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return _productos;

            return _productos
                .Where(p => p.Nombre.ToLower().Contains(texto.ToLower()))
                .ToList();
        }
    }
}
