using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bitacoras_pgsys
{
    public partial class modificar_bitacora : Form
    {
        public int cod;
        public modificar_bitacora()
        {
            InitializeComponent();
        }

        private void modificar_bitacora_Load(object sender, EventArgs e)
        {
            detalle_cliente.detalle_cliente webs = new detalle_cliente.detalle_cliente();
            detalle_cliente.datos_cliente_entrada crear = new detalle_cliente.datos_cliente_entrada();
            detalle_cliente.datos_cliente_salida res = new detalle_cliente.datos_cliente_salida();
            crear.codigo = cod.ToString();
            res = webs.Calldetalle_cliente(crear);
            if (!res.cod_datos.Equals(""))
            {
                tbEmpresa.Text = res.empresa_datos;
                tbTitulo.Text = res.titulo_datos;
                tbDescripcion.Text = res.descripcion_datos.Replace("\n","\r\n");
                this.Text = "Modificar Bitacora: " + res.titulo_datos;
                tbDescripcion.ReadOnly = true;
                cbEditar.Checked = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbEmpresa.Text == "") {
                MessageBox.Show("Debe ingresar el nombre de la empresa.");
                tbEmpresa.Focus();
            }
            else if(tbTitulo.Text == ""){
                MessageBox.Show("Debe ingresar un titulo descriptivo.");
                tbTitulo.Focus();
            }
            else if (tbDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripcion");
                tbDescripcion.Focus();
            }
            else {
                modificar_cliente.modificar_cliente webs = new modificar_cliente.modificar_cliente();
                modificar_cliente.datos_cliente_entrada crear = new modificar_cliente.datos_cliente_entrada();
                modificar_cliente.datos_cliente_salida res = new modificar_cliente.datos_cliente_salida();
                crear.cod_datos = cod.ToString();
                crear.descripcion_datos = tbDescripcion.Text;
                crear.empresa_datos = tbEmpresa.Text;
                crear.titulo_datos = tbTitulo.Text;
                crear.ultmod_datos = DateTime.Now.ToString();
                res = webs.Callmodificar_cliente(crear);
                if (res.codigo.Equals("0"))
                {
                    MessageBox.Show("Error al modificar el cliente.Error: " + res.respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Dispose();
            }
        }

        private void cbEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditar.Checked == true)
            {
                tbDescripcion.ReadOnly = false;
            }
            else {
                tbDescripcion.ReadOnly = true;
            }
        }

    }
}
