namespace MARKET_GRUPO_01.Presentaciones
{
    partial class V_Pedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Formbr = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.DgvDatos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPROD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalPROD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.DgvProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Agregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFiltro = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblUnidades = new System.Windows.Forms.Label();
            this.LblTotalPago = new System.Windows.Forms.Label();
            this.BtnDescartar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BtnGuardar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CmbCliente = new Guna.UI2.WinForms.Guna2ComboBox();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtCondicionId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DtpFechaPedido = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescuento = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Formbr
            // 
            this.Formbr.BorderRadius = 4;
            this.Formbr.ContainerControl = this;
            this.Formbr.DockIndicatorTransparencyValue = 0.6D;
            this.Formbr.DragForm = false;
            this.Formbr.TransparentWhileDrag = true;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 10;
            this.guna2Panel4.Controls.Add(this.DgvDatos);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.guna2Panel4.Location = new System.Drawing.Point(22, 332);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Padding = new System.Windows.Forms.Padding(10);
            this.guna2Panel4.Size = new System.Drawing.Size(1047, 217);
            this.guna2Panel4.TabIndex = 67;
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvDatos.ColumnHeadersHeight = 40;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.Codigo,
            this.Descripcion,
            this.PrecioUnd,
            this.CantidadPROD,
            this.SubTotalPROD,
            this.Descuento,
            this.Impuesto,
            this.Total,
            this.Eliminar});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvDatos.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvDatos.Location = new System.Drawing.Point(10, 10);
            this.DgvDatos.MultiSelect = false;
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowHeadersVisible = false;
            this.DgvDatos.RowHeadersWidth = 30;
            this.DgvDatos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvDatos.RowTemplate.DividerHeight = 2;
            this.DgvDatos.RowTemplate.Height = 30;
            this.DgvDatos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDatos.Size = new System.Drawing.Size(1027, 197);
            this.DgvDatos.TabIndex = 0;
            this.DgvDatos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvDatos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DgvDatos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DgvDatos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DgvDatos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DgvDatos.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvDatos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvDatos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DgvDatos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvDatos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvDatos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DgvDatos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvDatos.ThemeStyle.HeaderStyle.Height = 40;
            this.DgvDatos.ThemeStyle.ReadOnly = false;
            this.DgvDatos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvDatos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvDatos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvDatos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvDatos.ThemeStyle.RowsStyle.Height = 30;
            this.DgvDatos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DgvDatos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDatos_CellMouseClick);
            // 
            // IDProducto
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IDProducto.DefaultCellStyle = dataGridViewCellStyle8;
            this.IDProducto.HeaderText = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // PrecioUnd
            // 
            this.PrecioUnd.HeaderText = "Precio U.";
            this.PrecioUnd.Name = "PrecioUnd";
            // 
            // CantidadPROD
            // 
            this.CantidadPROD.HeaderText = "Cantidad";
            this.CantidadPROD.Name = "CantidadPROD";
            // 
            // SubTotalPROD
            // 
            this.SubTotalPROD.HeaderText = "SubTotal";
            this.SubTotalPROD.Name = "SubTotalPROD";
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            // 
            // Impuesto
            // 
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.Name = "Impuesto";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Eliminar
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Salmon;
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle9;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Remover";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.DgvProductos);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.guna2Panel1.Location = new System.Drawing.Point(274, 135);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.guna2Panel1.ShadowDecoration.Depth = 10;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.guna2Panel1.Size = new System.Drawing.Size(793, 156);
            this.guna2Panel1.TabIndex = 69;
            // 
            // DgvProductos
            // 
            this.DgvProductos.AllowUserToAddRows = false;
            this.DgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvProductos.ColumnHeadersHeight = 40;
            this.DgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agregar,
            this.Cantidad,
            this.SubTotal});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProductos.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvProductos.Location = new System.Drawing.Point(10, 0);
            this.DgvProductos.MultiSelect = false;
            this.DgvProductos.Name = "DgvProductos";
            this.DgvProductos.RowHeadersVisible = false;
            this.DgvProductos.RowHeadersWidth = 30;
            this.DgvProductos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DgvProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvProductos.RowTemplate.DividerHeight = 2;
            this.DgvProductos.RowTemplate.Height = 30;
            this.DgvProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.Size = new System.Drawing.Size(773, 156);
            this.DgvProductos.TabIndex = 0;
            this.DgvProductos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvProductos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DgvProductos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DgvProductos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DgvProductos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DgvProductos.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvProductos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.DgvProductos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DgvProductos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvProductos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvProductos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DgvProductos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvProductos.ThemeStyle.HeaderStyle.Height = 40;
            this.DgvProductos.ThemeStyle.ReadOnly = false;
            this.DgvProductos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvProductos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvProductos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvProductos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvProductos.ThemeStyle.RowsStyle.Height = 30;
            this.DgvProductos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DgvProductos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductos_CellContentClick_1);
            this.DgvProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductos_CellValueChanged);
            // 
            // Agregar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.Agregar.DefaultCellStyle = dataGridViewCellStyle3;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.HeaderText = "Agregar";
            this.Agregar.Name = "Agregar";
            this.Agregar.Text = "Agregar";
            this.Agregar.UseColumnTextForButtonValue = true;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cant.";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2ControlBox2);
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 33);
            this.panel1.TabIndex = 79;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.Location = new System.Drawing.Point(991, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 33);
            this.guna2ControlBox2.TabIndex = 59;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1036, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 33);
            this.guna2ControlBox1.TabIndex = 58;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(18, 36);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(253, 24);
            this.LblTitulo.TabIndex = 80;
            this.LblTitulo.Text = "Agregando Nuevo Pedido";
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(270, 71);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(167, 20);
            this.Usuario.TabIndex = 132;
            this.Usuario.Text = "Productos Disponibles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 133;
            this.label1.Text = "Cliente";
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.BackColor = System.Drawing.Color.Transparent;
            this.TxtFiltro.BorderRadius = 3;
            this.TxtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFiltro.DefaultText = "";
            this.TxtFiltro.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtFiltro.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtFiltro.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFiltro.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltro.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFiltro.IconLeft = global::MARKET_GRUPO_01.Properties.Resources.Filtro;
            this.TxtFiltro.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtFiltro.Location = new System.Drawing.Point(274, 96);
            this.TxtFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.PasswordChar = '\0';
            this.TxtFiltro.PlaceholderText = "Buscar";
            this.TxtFiltro.SelectedText = "";
            this.TxtFiltro.ShadowDecoration.BorderRadius = 10;
            this.TxtFiltro.ShadowDecoration.Depth = 10;
            this.TxtFiltro.ShadowDecoration.Enabled = true;
            this.TxtFiltro.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtFiltro.Size = new System.Drawing.Size(792, 32);
            this.TxtFiltro.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 20);
            this.label4.TabIndex = 139;
            this.label4.Text = "Productos agregados al pedido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 575);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 140;
            this.label5.Text = "Unidades Total:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(491, 575);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 141;
            this.label6.Text = "Precio Total:";
            // 
            // LblUnidades
            // 
            this.LblUnidades.AutoSize = true;
            this.LblUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUnidades.Location = new System.Drawing.Point(160, 575);
            this.LblUnidades.Name = "LblUnidades";
            this.LblUnidades.Size = new System.Drawing.Size(18, 20);
            this.LblUnidades.TabIndex = 142;
            this.LblUnidades.Text = "0";
            // 
            // LblTotalPago
            // 
            this.LblTotalPago.AutoSize = true;
            this.LblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalPago.Location = new System.Drawing.Point(606, 575);
            this.LblTotalPago.Name = "LblTotalPago";
            this.LblTotalPago.Size = new System.Drawing.Size(18, 20);
            this.LblTotalPago.TabIndex = 143;
            this.LblTotalPago.Text = "0";
            // 
            // BtnDescartar
            // 
            this.BtnDescartar.BackColor = System.Drawing.Color.Transparent;
            this.BtnDescartar.BorderRadius = 3;
            this.BtnDescartar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDescartar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDescartar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDescartar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDescartar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDescartar.FillColor = System.Drawing.Color.IndianRed;
            this.BtnDescartar.FillColor2 = System.Drawing.Color.RosyBrown;
            this.BtnDescartar.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDescartar.ForeColor = System.Drawing.Color.White;
            this.BtnDescartar.Location = new System.Drawing.Point(745, 559);
            this.BtnDescartar.Name = "BtnDescartar";
            this.BtnDescartar.ShadowDecoration.BorderRadius = 8;
            this.BtnDescartar.ShadowDecoration.Depth = 10;
            this.BtnDescartar.ShadowDecoration.Enabled = true;
            this.BtnDescartar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 5);
            this.BtnDescartar.Size = new System.Drawing.Size(159, 45);
            this.BtnDescartar.TabIndex = 65;
            this.BtnDescartar.Text = "Descartar";
            this.BtnDescartar.Click += new System.EventHandler(this.BtnDescartar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.BorderRadius = 3;
            this.BtnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnGuardar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnGuardar.FillColor2 = System.Drawing.Color.Gray;
            this.BtnGuardar.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(910, 559);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.ShadowDecoration.BorderRadius = 8;
            this.BtnGuardar.ShadowDecoration.Depth = 10;
            this.BtnGuardar.ShadowDecoration.Enabled = true;
            this.BtnGuardar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 5);
            this.BtnGuardar.Size = new System.Drawing.Size(159, 45);
            this.BtnGuardar.TabIndex = 64;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // CmbCliente
            // 
            this.CmbCliente.BackColor = System.Drawing.Color.Transparent;
            this.CmbCliente.BorderRadius = 4;
            this.CmbCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCliente.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbCliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbCliente.ItemHeight = 30;
            this.CmbCliente.Location = new System.Drawing.Point(22, 94);
            this.CmbCliente.MaxDropDownItems = 10;
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.ShadowDecoration.Depth = 10;
            this.CmbCliente.ShadowDecoration.Enabled = true;
            this.CmbCliente.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.CmbCliente.Size = new System.Drawing.Size(226, 36);
            this.CmbCliente.TabIndex = 144;
            this.CmbCliente.SelectedIndexChanged += new System.EventHandler(this.CmbCliente_SelectedIndexChanged);
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubTotal.Location = new System.Drawing.Point(407, 575);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(18, 20);
            this.LblSubTotal.TabIndex = 146;
            this.LblSubTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(260, 575);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 20);
            this.label8.TabIndex = 145;
            this.label8.Text = "Precio SubTotal:";
            // 
            // TxtCondicionId
            // 
            this.TxtCondicionId.BackColor = System.Drawing.Color.Transparent;
            this.TxtCondicionId.BorderRadius = 4;
            this.TxtCondicionId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtCondicionId.DefaultText = "";
            this.TxtCondicionId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtCondicionId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtCondicionId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtCondicionId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtCondicionId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtCondicionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCondicionId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtCondicionId.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtCondicionId.Location = new System.Drawing.Point(137, 244);
            this.TxtCondicionId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtCondicionId.Name = "TxtCondicionId";
            this.TxtCondicionId.PasswordChar = '\0';
            this.TxtCondicionId.PlaceholderText = "ID";
            this.TxtCondicionId.ReadOnly = true;
            this.TxtCondicionId.SelectedText = "";
            this.TxtCondicionId.ShadowDecoration.BorderRadius = 10;
            this.TxtCondicionId.ShadowDecoration.Depth = 10;
            this.TxtCondicionId.ShadowDecoration.Enabled = true;
            this.TxtCondicionId.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtCondicionId.Size = new System.Drawing.Size(110, 40);
            this.TxtCondicionId.TabIndex = 148;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(120, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 147;
            this.label7.Text = "Condicion Pago ID";
            // 
            // DtpFechaPedido
            // 
            this.DtpFechaPedido.BackColor = System.Drawing.Color.Transparent;
            this.DtpFechaPedido.BorderRadius = 3;
            this.DtpFechaPedido.Checked = true;
            this.DtpFechaPedido.CheckedState.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.CustomFormat = "dddd d MMMM, yyyy";
            this.DtpFechaPedido.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaPedido.HoverState.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.Location = new System.Drawing.Point(20, 169);
            this.DtpFechaPedido.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpFechaPedido.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpFechaPedido.Name = "DtpFechaPedido";
            this.DtpFechaPedido.ShadowDecoration.BorderRadius = 2;
            this.DtpFechaPedido.ShadowDecoration.Depth = 10;
            this.DtpFechaPedido.ShadowDecoration.Enabled = true;
            this.DtpFechaPedido.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.DtpFechaPedido.Size = new System.Drawing.Size(226, 36);
            this.DtpFechaPedido.TabIndex = 66;
            this.DtpFechaPedido.Value = new System.DateTime(2024, 4, 13, 16, 1, 59, 413);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 134;
            this.label2.Text = "Fecha Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 137;
            this.label3.Text = "Descuento";
            // 
            // TxtDescuento
            // 
            this.TxtDescuento.BackColor = System.Drawing.Color.Transparent;
            this.TxtDescuento.BorderRadius = 4;
            this.TxtDescuento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtDescuento.DefaultText = "";
            this.TxtDescuento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtDescuento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtDescuento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtDescuento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtDescuento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtDescuento.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtDescuento.Location = new System.Drawing.Point(20, 245);
            this.TxtDescuento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtDescuento.Name = "TxtDescuento";
            this.TxtDescuento.PasswordChar = '\0';
            this.TxtDescuento.PlaceholderText = "%";
            this.TxtDescuento.ReadOnly = true;
            this.TxtDescuento.SelectedText = "";
            this.TxtDescuento.ShadowDecoration.BorderRadius = 10;
            this.TxtDescuento.ShadowDecoration.Depth = 10;
            this.TxtDescuento.ShadowDecoration.Enabled = true;
            this.TxtDescuento.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtDescuento.Size = new System.Drawing.Size(110, 40);
            this.TxtDescuento.TabIndex = 138;
            // 
            // V_Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1081, 617);
            this.Controls.Add(this.TxtCondicionId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblSubTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbCliente);
            this.Controls.Add(this.BtnDescartar);
            this.Controls.Add(this.LblTotalPago);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblUnidades);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDescuento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.DtpFechaPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "V_Pedido";
            this.Text = "V_Pedido";
            this.Load += new System.EventHandler(this.V_Pedido_Load);
            this.Shown += new System.EventHandler(this.V_Pedido_Shown);
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm Formbr;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2DataGridView DgvDatos;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView DgvProductos;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        public System.Windows.Forms.Label LblTitulo;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label Usuario;
        private Guna.UI2.WinForms.Guna2TextBox TxtFiltro;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label LblTotalPago;
        public System.Windows.Forms.Label LblUnidades;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2GradientButton BtnDescartar;
        private Guna.UI2.WinForms.Guna2GradientButton BtnGuardar;
        public Guna.UI2.WinForms.Guna2ComboBox CmbCliente;
        public System.Windows.Forms.Label LblSubTotal;
        public System.Windows.Forms.Label label8;
        public Guna.UI2.WinForms.Guna2TextBox TxtCondicionId;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewButtonColumn Agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        public Guna.UI2.WinForms.Guna2TextBox TxtDescuento;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpFechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPROD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalPROD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}