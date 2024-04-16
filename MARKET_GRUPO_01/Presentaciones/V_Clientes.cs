﻿using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Clientes : Form
    {
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_Clientes ncliente;
        private readonly N_GrupoDescuento nGrupoDescuento;
        private readonly N_CondicionPago nCondicionPago;
        private string tituloListado;
        private string TextoBoton;

        public V_Clientes(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            ncliente = new N_Clientes();
            nGrupoDescuento = new N_GrupoDescuento();
            nCondicionPago = new N_CondicionPago();
            tituloListado = "LISTADO CLIENTES";
            TextoBoton = "NUEVO CLIENTE";
        }

        private void V_Clientes_Load(object sender, EventArgs e)
        {
            Recargar();
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            Recargar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
            Recargar();
        }

        private void BtnEiminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Recargar();
        }

        private void BtnClientes_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO CLIENTE";
            tituloListado = "LISTADO CLIENTES";
            Recargar();
        }

        private void BtnGrupoDescuento_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO GRUPO DESCUENTO";
            tituloListado = "LISTADO GRUPOS DESCUENTO";
            Recargar();
        }

        private void BtnCondicionPago_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVA CONDICION PAGO";
            tituloListado = "LISTADO CONDICIONES PAGO";
            Recargar();
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }
        private void Recargar()
        {
            DgvDatos.DataSource = null;
            if (BtnClientes.Checked)
            {
                N_Clientes nClientes = new N_Clientes();
                DgvDatos.DataSource = nClientes.ObtenerClientesGrid();
            }

            else if (BtnGrupoDescuento.Checked)
            {
                N_GrupoDescuento nGrupo = new N_GrupoDescuento();
                DgvDatos.DataSource = nGrupo.ObtenerGruposDescuento();
            }

            else if (BtnCondicionPago.Checked)
            {
                N_CondicionPago nCondicion = new N_CondicionPago();
                DgvDatos.DataSource = nCondicion.ObtenerCondicionesPago();
            }
            HabilitarSoloColumnaSeleccion(DgvDatos);
            LblTituloTab.Text = tituloListado;
            BtnNuevo.Text = TextoBoton;
        }

        private void SeleccionarSoloUno(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow Fila in dgv.Rows)
                {
                    DataGridViewCheckBoxCell OtroChk = (DataGridViewCheckBoxCell)Fila.Cells[e.ColumnIndex];
                    OtroChk.Value = (Fila.Index == e.RowIndex);
                }
            }
        }

        private void HabilitarSoloColumnaSeleccion(DataGridView dgv)
        {
            if (DgvDatos.DataSource != null)
            {
                foreach (DataGridViewColumn Columna in dgv.Columns)
                {

                    Columna.ReadOnly = true;
                }
                dgv.Columns[0].ReadOnly = false;
            }
        }

        private void Editar()
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int LineaID = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell ChkCelda = DgvDatos.Rows[LineaID].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (ChkCelda?.Value is true)
                {
                    int id = ObtenerID(LineaID);

                    if (BtnClientes.Checked)
                        AF.VentanaEmergente(new V_Cliente(id), inicio, true);
                    else if (BtnGrupoDescuento.Checked)
                        AF.VentanaEmergente(new V_GrupoDescuento(id), inicio, true);
                    else if (BtnCondicionPago.Checked)
                        AF.VentanaEmergente(new V_CondicionPago(id), inicio, true);
                }
            }
        }

        private void Nuevo()
        {
            if (BtnClientes.Checked)
                AF.VentanaEmergente(new V_Cliente(), inicio, true);
            else if (BtnGrupoDescuento.Checked)
                AF.VentanaEmergente(new V_GrupoDescuento(), inicio, true);
            else if (BtnCondicionPago.Checked)
                AF.VentanaEmergente(new V_CondicionPago(), inicio, true);
        }

        private void Eliminar()
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int LiniaID = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell ChkCelda = DgvDatos.Rows[LiniaID].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (ChkCelda?.Value is true)
                {
                    int id = ObtenerID(LiniaID);

                    DialogResult resultado = MessageBox.Show($"¿Está seguro de eliminar este {(BtnClientes.Checked ? "cliente" : (BtnGrupoDescuento.Checked ? "grupo descuento" : "condicion de pago"))}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        if (BtnClientes.Checked)
                            ncliente.EliminarCliente(id);
                        else if (BtnGrupoDescuento.Checked)
                            nGrupoDescuento.EliminarGrupoDescuento(id);
                        else if (BtnCondicionPago.Checked)
                            nCondicionPago.EliminarCondicionPago(id);
                    }
                }
            }
        }

        private int ObtenerID(int LiniaID)
        {
            int id = -1;
            if (BtnClientes.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["ClienteId"].Value;
            else if (BtnGrupoDescuento.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["GrupoDescuentoId"].Value;
            else if (BtnCondicionPago.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["CondicionPagoId"].Value;
            return id;
        }
    }
}
