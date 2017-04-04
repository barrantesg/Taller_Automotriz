using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Entidades;

namespace GUI
{
    public partial class FrmCliente : Form
    {
        AccesoDatosPostgre cnx;

        public FrmCliente(AccesoDatosPostgre pConexion)
        {
            InitializeComponent();
            this.cnx = pConexion;
            this.tpRefrescar_Click(this, null);
            
        }

        //INGRESO DE NUEVOS CLIENTES
        private void tpNuevo_Click(object sender, EventArgs e)
        {
            FrmEdiCliente ofrmEdiCliente = new FrmEdiCliente();
            ofrmEdiCliente.ShowDialog();
            if (ofrmEdiCliente.Aceptar)
            {
                ClienteD oClienteD = new ClienteD(this.cnx);
                if (oClienteD.agregarCliente(ofrmEdiCliente.getCliente()))
                {
                    this.tpRefrescar_Click(this, null);
                    MessageBox.Show("Cliente añadido al sistema satisfactoriamente");
                }
                else
                {
                    MessageBox.Show("Error agregando el cliente: " + oClienteD.Error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //REFRESCAR el DATAGRID
        private void tpRefrescar_Click(object sender, EventArgs e)
        {
            bool estado = true;
            ClienteD oClienteD = new ClienteD(this.cnx);
            DataSet dsetClientes = oClienteD.obtenerDataSetClientes(ref estado);

            if (estado)
            {
                this.dtCliente.DataSource = dsetClientes.Tables[0];
            }
        }

        private void tpEditar_Click(object sender, EventArgs e)
        {
            FrmEdiCliente ofrmEdiCliente = new FrmEdiCliente();
            //mostrar info de la fila en los respectivos textbox
            int fila = this.dtCliente.CurrentRow.Index;
            ofrmEdiCliente.txtCed.Text = this.dtCliente[0, fila].Value.ToString();
            ofrmEdiCliente.txtNombre.Text= this.dtCliente[1, fila].Value.ToString();
            ofrmEdiCliente.txtApe1.Text= this.dtCliente[2, fila].Value.ToString();
            ofrmEdiCliente.txtApe2.Text= this.dtCliente[3, fila].Value.ToString();
            ofrmEdiCliente.txtOfi.Text= this.dtCliente[4, fila].Value.ToString();
            ofrmEdiCliente.txtCasa.Text= this.dtCliente[5, fila].Value.ToString();
            ofrmEdiCliente.txtCel.Text= this.dtCliente[6, fila].Value.ToString();
            ofrmEdiCliente.txtFax.Text= this.dtCliente[7, fila].Value.ToString();
            ofrmEdiCliente.txtDire.Text= this.dtCliente[8, fila].Value.ToString();

            ofrmEdiCliente.ShowDialog();
            //inicio de edicion
            if (ofrmEdiCliente.Aceptar)
            {
                ClienteD oClienteD = new ClienteD(this.cnx);
                if (oClienteD.editarCliente(ofrmEdiCliente.getCliente()))
                {
                    this.tpRefrescar_Click(this, null);
                    MessageBox.Show("Cliente editado satisfactoriamente");
                }
                else
                {
                    MessageBox.Show("Error editando al cliente seleccionado: "+oClienteD.Error,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        private void dtCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.dtCliente.CurrentRow.Index;
            Cliente oCliente = new Cliente(this.dtCliente[0, fila].Value.ToString(), this.dtCliente[1, fila].Value.ToString(),
                this.dtCliente[2, fila].Value.ToString(), this.dtCliente[3, fila].Value.ToString(), this.dtCliente[4, fila].Value.ToString(),
                this.dtCliente[5, fila].Value.ToString(), this.dtCliente[6, fila].Value.ToString(),
                this.dtCliente[7, fila].Value.ToString(), this.dtCliente[8, fila].Value.ToString());

            ClienteD oClienteD = new ClienteD(this.cnx);
            if (oClienteD.eliminaCliente(oCliente))
            {
                this.tpRefrescar_Click(this, null);
                MessageBox.Show("Cliente eliminado satisfactoriamente");
            }else
            {
                MessageBox.Show("Error eliminando al cliente: " + oClienteD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
