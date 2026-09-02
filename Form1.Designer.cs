namespace GestorProductosPedroMiranda
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            txtNombre = new TextBox();
            txtStock = new TextBox();
            txtPrecio = new TextBox();
            btnAgregar = new Button();
            dgvProductos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnExportar = new Button();
            lblContador = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(6, 61);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Mouse inalambrico";
            txtNombre.Size = new Size(284, 34);
            txtNombre.TabIndex = 0;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(296, 61);
            txtStock.Name = "txtStock";
            txtStock.PlaceholderText = "Ej: 10";
            txtStock.Size = new Size(190, 34);
            txtStock.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(492, 61);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ej: 15000";
            txtPrecio.Size = new Size(187, 34);
            txtPrecio.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DodgerBlue;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(695, 30);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(236, 76);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RoyalBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.Gainsboro;
            dgvProductos.Location = new Point(25, 152);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.RowTemplate.Height = 35;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1126, 220);
            dgvProductos.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 5;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(296, 30);
            label2.Name = "label2";
            label2.Size = new Size(64, 28);
            label2.TabIndex = 6;
            label2.Text = "Stock:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(492, 30);
            label3.Name = "label3";
            label3.Size = new Size(70, 28);
            label3.TabIndex = 7;
            label3.Text = "Precio:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(6, 85);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre...";
            txtBuscar.Size = new Size(199, 34);
            txtBuscar.TabIndex = 8;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Coral;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(211, 44);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(194, 80);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "🔍 Buscar Producto";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(686, 85);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(208, 39);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "🗑 Eliminar Producto";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.SkyBlue;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(900, 22);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(209, 102);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "✎ Editar Producto";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(686, 22);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(208, 57);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "✕ Cancelar Edición";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.LightSeaGreen;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(937, 30);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(172, 76);
            btnExportar.TabIndex = 13;
            btnExportar.Text = "⬇ Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.ForeColor = Color.Black;
            lblContador.Location = new Point(6, 44);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(118, 28);
            lblContador.TabIndex = 14;
            lblContador.Text = "0 productos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(btnExportar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Location = new Point(25, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1124, 122);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Añadir Nuevo Producto";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Controls.Add(btnEditar);
            groupBox2.Controls.Add(txtBuscar);
            groupBox2.Controls.Add(lblContador);
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Location = new Point(25, 368);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1124, 134);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Acciones de Búsqueda y Resumen";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1166, 514);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvProductos);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "TechZone - Gestor de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtStock;
        private TextBox txtPrecio;
        private Button btnAgregar;
        private DataGridView dgvProductos;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnExportar;
        private Label lblContador;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
