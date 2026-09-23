using GestorProductosPedroMiranda.Controllers;
using GestorProductosPedroMiranda.Models;

namespace GestorProductosPedroMiranda
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var repo = new JsonRepository<Producto>("productos.json");
            var controller = new ProductoController(repo);
            var form = new Form1(controller);

            Application.Run(form);
        }
    }
}