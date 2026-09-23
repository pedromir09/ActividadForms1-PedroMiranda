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
        private readonly IRepository<Producto> _repo;

        public ProductoController(IRepository<Producto> repo)
        {
            _repo = repo;
        }

        public void Agregar(string nombre, int stock, decimal precio)
        {
            //el Id no se asigna aca, lo calcula el repositorio en Agregar()
            var producto = new Producto
            {
                Nombre = nombre,
                Stock = stock,
                Precio = precio
            };
            _repo.Agregar(producto);
        }

        public List<Producto> ObtenerTodos() => _repo.LeerTodos();

        public void Eliminar(int id) => _repo.Eliminar(id);

        public void Modificar(Producto modificado) => _repo.Actualizar(modificado);

        public List<Producto> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return _repo.LeerTodos();

            return _repo.LeerTodos()
                .Where(p => p.Nombre.ToLower().Contains(texto.ToLower()))
                .ToList();
        }
    }
}
