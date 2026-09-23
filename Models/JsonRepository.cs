using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorProductosPedroMiranda.Models
{
    public class JsonRepository<T> : IRepository<T> where T : IEntidad
    {
        private readonly string _ruta;

        public JsonRepository(string ruta)
        {
            _ruta = ruta;
        }

        //lee todo el archivo, si no existe todavia, devuelve lista vacia en vez de una excepcion
        public List<T> LeerTodos()
        {
            if (!File.Exists(_ruta))
                return new List<T>();

            var json = File.ReadAllText(_ruta);

            //Deserialize puede devolver null, el ?? evita que eso rompa el programa
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public T? BuscarPorId(int id)
            => LeerTodos().FirstOrDefault(e => e.Id == id);

        public void Agregar(T item)
        {
            var lista = LeerTodos();

            //el Id lo asigna el repositorio, no quien llama a este metodo
            item.Id = lista.Count > 0 ? lista.Max(e => e.Id) + 1 : 1;

            lista.Add(item);
            Persistir(lista);
        }

        public void Actualizar(T item)
        {
            var lista = LeerTodos();
            var idx = lista.FindIndex(e => e.Id == item.Id);

            if (idx >= 0)
                lista[idx] = item;

            Persistir(lista);
        }

        public void Eliminar(int id)
        {
            var lista = LeerTodos();
            lista.RemoveAll(e => e.Id == id);
            Persistir(lista);
        }

        //privado a proposito, ni el Controller ni el Form deben poder llamarlo
        private void Persistir(List<T> lista)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_ruta, JsonSerializer.Serialize(lista, opts));
        }
    }
}
