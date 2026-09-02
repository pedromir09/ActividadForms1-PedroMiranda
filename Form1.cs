using GestorProductosPedroMiranda.Controllers;
using GestorProductosPedroMiranda.Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace GestorProductosPedroMiranda
{
    public partial class Form1 : Form
    {
        private ProductoController _controller;
        private bool _modoEdicion = false; //indica si se esta editando o cargando uno nuevo
        private Producto _productoEditando = null; //guarda referencia al producto que se esta editando
        private BindingSource _bindingSource = new BindingSource(); //administra la conexion entre la lista y el grid

        public Form1(ProductoController controller)
        {
            InitializeComponent();
            _controller = controller;

            //productos de ejemplo precargados
            _controller.Agregar("Mouse Gamer RGB", 2, 15000);
            _controller.Agregar("Teclado Mecanico", 7, 45000);
            _controller.Agregar("Monitor 24 pulgadas", 15, 180000);
            _controller.Agregar("Auriculares Bluetooth", 25, 32000);
            _controller.Agregar("Webcam Full HD", 0, 28000);

            //el grid mira al BindingSource, no directamente a la lista
            dgvProductos.DataSource = _bindingSource;

            //se dispara cuando el form ya termino de crearse visualmente, asi se arma la tabla con colores
            this.Load += Form1_Load;
        }

        //se ejecuta automaticamente cuando el form ya se mostro/esta listo
        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //se lee el texto del campo Nombre y se le saca espacios de mas
            string nombre = txtNombre.Text.Trim();

            //validacion - el nombre no puede estar vacio
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacio.");
                txtNombre.Focus();
                return;
            }

            //validacion - el stock tiene que ser un numero entero y no negativo
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock invalido.");
                txtStock.Focus();
                return;
            }

            //validacion - el precio tiene que ser un decimal y mayor a 0
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio invalido.");
                txtPrecio.Focus();
                return;
            }

            //bifurcacion - segun el modo, actualiza o crea
            if (_modoEdicion)
            {
                //modifica el objeto que ya esta en la lista
                _productoEditando.Nombre = nombre;
                _productoEditando.Stock = stock;
                _productoEditando.Precio = precio;

                _controller.Modificar(_productoEditando);

                SalirModoEdicion();
            }
            else
            {
                //comportamiento normal, se agrega un producto nuevo
                _controller.Agregar(nombre, stock, precio);
            }

            ActualizarTabla();
            LimpiarCampos();
        }

        //metodo para salir del modo edicion, vuelve el form a su estado normal
        private void SalirModoEdicion()
        {
            _modoEdicion = false;
            _productoEditando = null;
            ActualizarBotones();
        }

        //metodo pra actualizar la tabla - si le pasa una lista muestra esa, si no le pasa nada, trae todos los productos
        private void ActualizarTabla(List<Producto> lista = null)
        {
            var productos = lista ?? _controller.ObtenerTodos();

            //se fuerza el refresco del BindingSource reasignando su DataSource
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = productos;

            //se actualiza el contador con la cantidad de productos que se estan mostrando
            lblContador.Text = $"{productos.Count} productos";

            //se aplica el formato de precio cada vez que se refresca la tabla - al reasignar el DataSource el DataGridView olvida los formatos anteriores
            FormatearColumnas();
            ColorearFilas();
        }

        //vacia los 3 textbox y devuelve el cursor al primero
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtNombre.Focus();
        }

        //devuelve el producto de la fila que se seleccio en la tabla. si no se selecciona ninguna devuelve null
        private Producto ObtenerSeleccionado()
        {
            //si no hay ninguna fila marcada, no hay nada que devolver
            if (dgvProductos.SelectedRows.Count == 0)
                return null;

            //SelectedRows[0] - primera fila marcada
            //DataBoundItem - objeto Producto original que esta detras de esa fila
            //"as Producto" - convierte al tipo correcto
            return dgvProductos.SelectedRows[0].DataBoundItem as Producto;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var p = ObtenerSeleccionado(); //busca un producto esta seleccionado en la tabla

            if (p == null) return;

            //pide confirmacion antes de borrar
            var confirmar = MessageBox.Show(
                $"Desea eliminar {p.Nombre}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            //si se elige si, ahi se borra
            if (confirmar == DialogResult.Yes)
            {
                _controller.Eliminar(p.Id);
                ActualizarTabla();
            }
        }

        //ejecuta al hacer clic en el boton editar
        //toma el producto seleccionado y se activa el modo edicion
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            var p = ObtenerSeleccionado();
            if (p == null) return;

            _modoEdicion = true;
            _productoEditando = p; //guarda referencia al objeto real de la lista

            //cargan los datos actuales del producto en los campos
            txtNombre.Text = p.Nombre;
            txtStock.Text = p.Stock.ToString();
            txtPrecio.Text = p.Precio.ToString();

            ActualizarBotones();
        }

        //centraliza los cambios visuales segun el modo, normal o edicion
        //un solo lugar para controlar texto, visibilidad y estado de los botones
        private void ActualizarBotones()
        {
            //operador ternario: condicion ? valorSiTrue : valorSiFalse
            btnAgregar.Text = _modoEdicion ? "Guardar cambios" : "Agregar";
            btnCancelar.Visible = _modoEdicion;
            btnEditar.Enabled = !_modoEdicion;
        }

        //ejecuta al hacer clic en cancelar
        //sale del modo edicion sin guardar ningun cambio
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SalirModoEdicion();
            LimpiarCampos();
        }

        //ejecuta al hacer clic en buscar
        //filtra la tabla en base al texto escrito en txtBuscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var resultado = _controller.Buscar(txtBuscar.Text.Trim());
            ActualizarTabla(resultado);

        }

        //ejecuta al hacer clic en exportar
        //se genera un archivo .txt con todos los productos en la carpeta Documentos de la compu
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var productos = _controller.ObtenerTodos();

                //arma la ruta: carpeta documentos + nombre del archivo
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "productos_exportados.txt");

                //using asegura cerrar el archivo al terminar
                using (StreamWriter sw = new StreamWriter(ruta))
                {
                    sw.WriteLine("=== LISTADO DE PRODUCTOS ===");
                    sw.WriteLine();

                    foreach (var p in productos)
                    {
                        sw.WriteLine($"Id: {p.Id} | Nombre: {p.Nombre} | Stock: {p.Stock} | Precio: {p.Precio:C2}");
                    }

                    sw.WriteLine();
                    sw.WriteLine($"Total de productos: {productos.Count}");
                }

                MessageBox.Show($"Archivo exportado en:\n{ruta}", "Exportacion exitosa");
            }
            catch (Exception ex)
            {
                //si algo falla muestra error
                MessageBox.Show($"Error al exportar: {ex.Message}");
            }
        }

        //formato a la columna Precio: $ con puntos de miles
        //CultureInfo("es-AR") - formato numerico argentino
        private void FormatearColumnas()
        {
            if (dgvProductos.Columns["Precio"] != null)
            {
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C0";
                dgvProductos.Columns["Precio"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");
            }
        }

        //recorre todas las filas de la tabla - un color de fondo segun el stock del product
        private void ColorearFilas()
        {
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                //igual que en ObtenerSeleccionado(): recuperamos el Producto que esta "detras" de esta fila
                var p = fila.DataBoundItem as Producto;
                if (p == null) continue; // si por algo no hay producto, saltea esta fila

                System.Drawing.Color color;

                if (p.Stock <= 3)
                    color = System.Drawing.Color.MistyRose;
                else if (p.Stock <= 10)
                    color = System.Drawing.Color.LightYellow;
                else
                    color = System.Drawing.Color.LightGreen;

                //color normal - fila sin seleccionar
                fila.DefaultCellStyle.BackColor = color;

                //color cuando esta seleccionada, version mas oscura del mismo colr
                fila.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(color);
                fila.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            }
        }


    }
}
