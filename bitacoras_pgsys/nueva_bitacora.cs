using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bitacoras_pgsys
{
    public partial class nueva_bitacora : Form
    {
        public nueva_bitacora()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbEmpresa.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la empresa.");
                tbEmpresa.Focus();
            }
            else if (tbTitulo.Text == "")
            {
                MessageBox.Show("Debe ingresar un titulo descriptivo.");
                tbTitulo.Focus();
            }
            else if (tbDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripcion");
                tbDescripcion.Focus();
            }
            else
            {
                crear_cliente.crear_cliente webs = new crear_cliente.crear_cliente();
                crear_cliente.datos_cliente_entrada crear = new crear_cliente.datos_cliente_entrada();
                crear_cliente.datos_cliente_salida res = new crear_cliente.datos_cliente_salida();
                crear.titulo = tbTitulo.Text;
                crear.empresa = tbEmpresa.Text;
                crear.descripcion = tbDescripcion.Text;
                res = webs.Callcrear_cliente(crear);
                if (res.codigo.Equals("0"))
                {
                    MessageBox.Show("Error al crear el cliente.Error: " + res.respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Dispose();
            }
        }
    }
}
