namespace MARKET_GRUPO_01.Presentaciones
{
    partial class V_PedidoEdit
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.FormBr = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ChkActivo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSubTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.Usuario = new System.Windows.Forms.Label();
            this.CmbClientes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblpedido = new System.Windows.Forms.Label();
            this.TxtIdPedido = new Guna.UI2.WinForms.Guna2TextBox();
            this.DtpFechaPedido = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDescuento = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtImpuesto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnDescartar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BtnGuardar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormBr
            // 
            this.FormBr.AnimateWindow = true;
            this.FormBr.BorderRadius = 3;
            this.FormBr.ContainerControl = this;
            this.FormBr.DockIndicatorTransparencyValue = 0.6D;
            this.FormBr.DragForm = false;
            this.FormBr.TransparentWhileDrag = true;
            // 
            // ChkActivo
            // 
            this.ChkActivo.AutoSize = true;
            this.ChkActivo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChkActivo.CheckedState.BorderRadius = 0;
            this.ChkActivo.CheckedState.BorderThickness = 0;
            this.ChkActivo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChkActivo.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkActivo.Location = new System.Drawing.Point(51, 302);
            this.ChkActivo.Name = "ChkActivo";
            this.ChkActivo.Size = new System.Drawing.Size(70, 25);
            this.ChkActivo.TabIndex = 80;
            this.ChkActivo.Text = "Activo";
            this.ChkActivo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ChkActivo.UncheckedState.BorderRadius = 0;
            this.ChkActivo.UncheckedState.BorderThickness = 0;
            this.ChkActivo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 79;
            this.label8.Text = "Estado";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(47, 215);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(107, 20);
            this.LblNombre.TabIndex = 72;
            this.LblNombre.Text = "Fecha Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "SubTotal";
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.TxtSubTotal.BorderRadius = 3;
            this.TxtSubTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtSubTotal.DefaultText = "";
            this.TxtSubTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtSubTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtSubTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSubTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSubTotal.Enabled = false;
            this.TxtSubTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSubTotal.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtSubTotal.Location = new System.Drawing.Point(332, 112);
            this.TxtSubTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.PasswordChar = '\0';
            this.TxtSubTotal.PlaceholderText = "SubTotal";
            this.TxtSubTotal.SelectedText = "";
            this.TxtSubTotal.ShadowDecoration.BorderRadius = 4;
            this.TxtSubTotal.ShadowDecoration.Depth = 10;
            this.TxtSubTotal.ShadowDecoration.Enabled = true;
            this.TxtSubTotal.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtSubTotal.Size = new System.Drawing.Size(230, 36);
            this.TxtSubTotal.TabIndex = 69;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(47, 152);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(76, 20);
            this.Usuario.TabIndex = 68;
            this.Usuario.Text = "Id Cliente";
            // 
            // CmbClientes
            // 
            this.CmbClientes.BackColor = System.Drawing.Color.Transparent;
            this.CmbClientes.BorderRadius = 3;
            this.CmbClientes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClientes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbClientes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CmbClientes.ItemHeight = 30;
            this.CmbClientes.Location = new System.Drawing.Point(46, 176);
            this.CmbClientes.Name = "CmbClientes";
            this.CmbClientes.ShadowDecoration.BorderRadius = 4;
            this.CmbClientes.ShadowDecoration.Depth = 10;
            this.CmbClientes.ShadowDecoration.Enabled = true;
            this.CmbClientes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.CmbClientes.Size = new System.Drawing.Size(226, 36);
            this.CmbClientes.TabIndex = 81;
            // 
            // lblpedido
            // 
            this.lblpedido.AutoSize = true;
            this.lblpedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpedido.Location = new System.Drawing.Point(47, 87);
            this.lblpedido.Name = "lblpedido";
            this.lblpedido.Size = new System.Drawing.Size(79, 20);
            this.lblpedido.TabIndex = 83;
            this.lblpedido.Text = "Pedido ID";
            // 
            // TxtIdPedido
            // 
            this.TxtIdPedido.BackColor = System.Drawing.Color.Transparent;
            this.TxtIdPedido.BorderRadius = 3;
            this.TxtIdPedido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtIdPedido.DefaultText = "";
            this.TxtIdPedido.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtIdPedido.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtIdPedido.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtIdPedido.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtIdPedido.Enabled = false;
            this.TxtIdPedido.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtIdPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdPedido.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtIdPedido.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtIdPedido.Location = new System.Drawing.Point(46, 112);
            this.TxtIdPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtIdPedido.Name = "TxtIdPedido";
            this.TxtIdPedido.PasswordChar = '\0';
            this.TxtIdPedido.PlaceholderText = "Pedido ID";
            this.TxtIdPedido.SelectedText = "";
            this.TxtIdPedido.ShadowDecoration.BorderRadius = 4;
            this.TxtIdPedido.ShadowDecoration.Depth = 10;
            this.TxtIdPedido.ShadowDecoration.Enabled = true;
            this.TxtIdPedido.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtIdPedido.Size = new System.Drawing.Size(226, 36);
            this.TxtIdPedido.TabIndex = 82;
            // 
            // DtpFechaPedido
            // 
            this.DtpFechaPedido.BackColor = System.Drawing.Color.Transparent;
            this.DtpFechaPedido.BorderRadius = 3;
            this.DtpFechaPedido.Checked = true;
            this.DtpFechaPedido.CheckedState.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.CustomFormat = "dddd d MMMM, yyyy";
            this.DtpFechaPedido.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaPedido.HoverState.FillColor = System.Drawing.Color.White;
            this.DtpFechaPedido.Location = new System.Drawing.Point(46, 239);
            this.DtpFechaPedido.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpFechaPedido.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpFechaPedido.Name = "DtpFechaPedido";
            this.DtpFechaPedido.ShadowDecoration.BorderRadius = 2;
            this.DtpFechaPedido.ShadowDecoration.Depth = 10;
            this.DtpFechaPedido.ShadowDecoration.Enabled = true;
            this.DtpFechaPedido.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.DtpFechaPedido.Size = new System.Drawing.Size(226, 36);
            this.DtpFechaPedido.TabIndex = 84;
            this.DtpFechaPedido.Value = new System.DateTime(2024, 4, 13, 16, 1, 59, 413);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(336, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 86;
            this.label1.Text = "Descuento";
            // 
            // TxtDescuento
            // 
            this.TxtDescuento.BackColor = System.Drawing.Color.Transparent;
            this.TxtDescuento.BorderRadius = 3;
            this.TxtDescuento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtDescuento.DefaultText = "";
            this.TxtDescuento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtDescuento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtDescuento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtDescuento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtDescuento.Enabled = false;
            this.TxtDescuento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtDescuento.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtDescuento.Location = new System.Drawing.Point(332, 177);
            this.TxtDescuento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDescuento.Name = "TxtDescuento";
            this.TxtDescuento.PasswordChar = '\0';
            this.TxtDescuento.PlaceholderText = "Descuento";
            this.TxtDescuento.SelectedText = "";
            this.TxtDescuento.ShadowDecoration.BorderRadius = 4;
            this.TxtDescuento.ShadowDecoration.Depth = 10;
            this.TxtDescuento.ShadowDecoration.Enabled = true;
            this.TxtDescuento.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtDescuento.Size = new System.Drawing.Size(230, 36);
            this.TxtDescuento.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "Impuesto";
            // 
            // TxtImpuesto
            // 
            this.TxtImpuesto.BackColor = System.Drawing.Color.Transparent;
            this.TxtImpuesto.BorderRadius = 3;
            this.TxtImpuesto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtImpuesto.DefaultText = "";
            this.TxtImpuesto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtImpuesto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtImpuesto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtImpuesto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtImpuesto.Enabled = false;
            this.TxtImpuesto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImpuesto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtImpuesto.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtImpuesto.Location = new System.Drawing.Point(332, 242);
            this.TxtImpuesto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtImpuesto.Name = "TxtImpuesto";
            this.TxtImpuesto.PasswordChar = '\0';
            this.TxtImpuesto.PlaceholderText = "Impuesto";
            this.TxtImpuesto.SelectedText = "";
            this.TxtImpuesto.ShadowDecoration.BorderRadius = 4;
            this.TxtImpuesto.ShadowDecoration.Depth = 10;
            this.TxtImpuesto.ShadowDecoration.Enabled = true;
            this.TxtImpuesto.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtImpuesto.Size = new System.Drawing.Size(230, 36);
            this.TxtImpuesto.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(336, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 90;
            this.label4.Text = "Total";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.Transparent;
            this.TxtTotal.BorderRadius = 3;
            this.TxtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtTotal.DefaultText = "";
            this.TxtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtTotal.Enabled = false;
            this.TxtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtTotal.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.TxtTotal.Location = new System.Drawing.Point(332, 307);
            this.TxtTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.PasswordChar = '\0';
            this.TxtTotal.PlaceholderText = "Total";
            this.TxtTotal.SelectedText = "";
            this.TxtTotal.ShadowDecoration.BorderRadius = 4;
            this.TxtTotal.ShadowDecoration.Depth = 10;
            this.TxtTotal.ShadowDecoration.Enabled = true;
            this.TxtTotal.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.TxtTotal.Size = new System.Drawing.Size(230, 36);
            this.TxtTotal.TabIndex = 89;
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
            this.BtnDescartar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDescartar.ForeColor = System.Drawing.Color.White;
            this.BtnDescartar.Location = new System.Drawing.Point(152, 365);
            this.BtnDescartar.Name = "BtnDescartar";
            this.BtnDescartar.ShadowDecoration.BorderRadius = 4;
            this.BtnDescartar.ShadowDecoration.Depth = 10;
            this.BtnDescartar.ShadowDecoration.Enabled = true;
            this.BtnDescartar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 5);
            this.BtnDescartar.Size = new System.Drawing.Size(149, 45);
            this.BtnDescartar.TabIndex = 94;
            this.BtnDescartar.Text = "Descartar";
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
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(308, 365);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.ShadowDecoration.BorderRadius = 4;
            this.BtnGuardar.ShadowDecoration.Depth = 10;
            this.BtnGuardar.ShadowDecoration.Enabled = true;
            this.BtnGuardar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 5);
            this.BtnGuardar.Size = new System.Drawing.Size(149, 45);
            this.BtnGuardar.TabIndex = 93;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2ControlBox2);
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 33);
            this.panel1.TabIndex = 92;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.Location = new System.Drawing.Point(534, 0);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(579, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 33);
            this.guna2ControlBox1.TabIndex = 58;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(208, 45);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(176, 25);
            this.LblTitulo.TabIndex = 91;
            this.LblTitulo.Text = "Agregar Cliente";
            // 
            // V_PedidoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.BtnDescartar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtImpuesto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDescuento);
            this.Controls.Add(this.DtpFechaPedido);
            this.Controls.Add(this.lblpedido);
            this.Controls.Add(this.TxtIdPedido);
            this.Controls.Add(this.CmbClientes);
            this.Controls.Add(this.ChkActivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSubTotal);
            this.Controls.Add(this.Usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "V_PedidoEdit";
            this.Text = "V_Detalles";
            this.Load += new System.EventHandler(this.V_Detalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2BorderlessForm FormBr;
        public Guna.UI2.WinForms.Guna2CheckBox ChkActivo;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label LblNombre;
        public System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox TxtSubTotal;
        public System.Windows.Forms.Label Usuario;
        public Guna.UI2.WinForms.Guna2ComboBox CmbClientes;
        public System.Windows.Forms.Label lblpedido;
        public Guna.UI2.WinForms.Guna2TextBox TxtIdPedido;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpFechaPedido;
        public System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2TextBox TxtTotal;
        public System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox TxtImpuesto;
        public System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox TxtDescuento;
        public Guna.UI2.WinForms.Guna2GradientButton BtnDescartar;
        public Guna.UI2.WinForms.Guna2GradientButton BtnGuardar;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        public System.Windows.Forms.Label LblTitulo;
    }
}