using GestorProductosPedroMiranda.Controllers;

namespace GestorProductosPedroMiranda
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var controller = new ProductoController();
            var form = new Form1(controller);

            Application.Run(form);
        }
    }
}