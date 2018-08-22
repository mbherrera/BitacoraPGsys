using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bitacoras_pgsys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int cam;
        DataTable aux;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nueva_bitacora nuevo = new nueva_bitacora();
            nuevo.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void activar_proceso(string param)
        {
            aux.Rows.Clear();
            tsslEstado.Show();
            if (!CargarClientes.IsBusy) {
                CargarClientes.RunWorkerAsync(param);
            }
        }
        private void desactivar_proceso() {
            if (CargarClientes.IsBusy) {
                CargarClientes.CancelAsync();
            }
        }
        private void cargar() {
            if (aux.Rows.Count > 0)
            {
                dgvBitacoras.Refresh();
                dgvBitacoras.DataSource = aux;
                this.dgvBitacoras.Columns[3].Visible = false;
                this.dgvBitacoras.Columns[0].HeaderText = "Codigo";
                this.dgvBitacoras.Columns[0].Width = 100;

                this.dgvBitacoras.Columns[1].HeaderText = "Empresa";
                this.dgvBitacoras.Columns[1].Width = 300;

                this.dgvBitacoras.Columns[2].HeaderText = "Titulo Descripcion";
                this.dgvBitacoras.Columns[2].Width = 300;

                this.dgvBitacoras.Columns[4].HeaderText = "Ultima Modificacion";
                this.dgvBitacoras.Columns[4].Width = 200;

                this.dgvBitacoras.RowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
                this.dgvBitacoras.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                this.dgvBitacoras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvBitacoras.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tsslEstado.Hide();
            }
            else { this.dgvBitacoras.DataSource = null; }
        }

        private void tbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                activar_proceso(tbBuscar.Text);
            }
        }

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = funciones_generales.ingreso_datos.validar_texto(e,1);
            if (e.KeyChar == (char)Keys.Enter)
            {
                activar_proceso(tbBuscar.Text);
            }
        }

        private void dgvBitacoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod;
            cod = int.Parse(dgvBitacoras[0, dgvBitacoras.CurrentRow.Index].Value.ToString());
            modificar_bitacora modificar = new modificar_bitacora();
            modificar.cod = cod;
            modificar.Show();
        }

        private void dgvBitacoras_KeyDown(object sender, KeyEventArgs e)
        {
            int cod;string titulo;DialogResult result;
            if (e.KeyCode == Keys.Delete) {
                e.Handled = true;
                cod = int.Parse(dgvBitacoras[0, dgvBitacoras.CurrentRow.Index].Value.ToString());
                titulo = (string)dgvBitacoras[2, dgvBitacoras.CurrentRow.Index].Value;
                result = MessageBox.Show("Esta seguro que desea eliminar la bitacora: " + titulo, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes) {
                    eliminar_cliente.eliminar_cliente webs = new eliminar_cliente.eliminar_cliente();
                    eliminar_cliente.datos_cliente_entrada crear = new eliminar_cliente.datos_cliente_entrada();
                    eliminar_cliente.datos_cliente_salida res = new eliminar_cliente.datos_cliente_salida();
                    crear.codigo = cod.ToString();
                    res = webs.Calleliminar_cliente(crear);
                    if (res.codigo.Equals("0"))
                    {
                        MessageBox.Show("Error al eliminar el cliente seleccionado.Error: " + res.respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else { activar_proceso(""); }
                }
            }
            else if (e.KeyCode == Keys.F5) { activar_proceso(""); }
        }

        private void CargarClientes_DoWork(object sender, DoWorkEventArgs e)
        {
            string p;
            p = (string)e.Argument;
            try
            {
                lista_clientes.lista_clientes webs = new lista_clientes.lista_clientes();
                lista_clientes.datos_cliente_entrada crear = new lista_clientes.datos_cliente_entrada();
                lista_clientes.Cliente[] arreglo;
                crear.param1 = tbBuscar.Text;
                arreglo = webs.arreglo_clientes(crear);
                DataRow fil;
                foreach (lista_clientes.Cliente cli in arreglo)
                {
                    fil = aux.NewRow();
                    fil["Codigo"] = cli.cod_datos;
                    fil["Empresa"] = cli.empresa_datos;
                    fil["Titulo"] = cli.titulo_datos;
                    fil["Descripcion"] = cli.descripcion_datos;
                    fil["Modificacion"] = cli.ultmod_datos;
                    aux.Rows.Add(fil);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error al cargar los datos.Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarClientes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cargar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aux = new DataTable();
            DataColumn col_cod = new DataColumn("Codigo");
            col_cod.DataType = System.Type.GetType("System.String");
            aux.Columns.Add(col_cod);
            DataColumn col_emp = new DataColumn("Empresa");
            col_emp.DataType = System.Type.GetType("System.String");
            aux.Columns.Add(col_emp);
            DataColumn col_tit = new DataColumn("Titulo");
            col_tit.DataType = System.Type.GetType("System.String");
            aux.Columns.Add(col_tit);
            DataColumn col_des = new DataColumn("Descripcion");
            col_des.DataType = System.Type.GetType("System.String");
            aux.Columns.Add(col_des);
            DataColumn col_mod = new DataColumn("Modificacion");
            col_mod.DataType = System.Type.GetType("System.String");
            aux.Columns.Add(col_mod);

            activar_proceso("");
            tsslEstado.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            desactivar_proceso();
        }
    }
}
