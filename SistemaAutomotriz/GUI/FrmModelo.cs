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
    public partial class FrmModelo : Form
    {
        AccesoDatosPostgre cnx;
        public FrmModelo(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.refrescarGrid();
        }

        private void tpNuevo_Click(object sender, EventArgs e)
        {
            FrmEdiModelo ofrmEdiModelo = new FrmEdiModelo(this.cnx);
            ofrmEdiModelo.ShowDialog();
            if (ofrmEdiModelo.Aceptar)
            {
                ModeloD oModeloD = new ModeloD(this.cnx);
                if (oModeloD.agregarModelo(ofrmEdiModelo.getModelo()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Modelo agregado satisfactoriamente");
                }
                else
                {
                    MessageBox.Show("Error agregando el modelo: " + oModeloD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void tpEditar_Click(object sender, EventArgs e)
        {
            FrmEdiModelo ofrmEdiModelo = new FrmEdiModelo(this.cnx);
            int fila = this.dtModelo.CurrentRow.Index;
           // ofrmEdiModelo.txtCod.Text= this.dtModelo[0, fila].Value.ToString();
            ofrmEdiModelo.comboMarca.Text= this.dtModelo[1, fila].Value.ToString();
            ofrmEdiModelo.txtDescripcion.Text= this.dtModelo[2, fila].Value.ToString();

            ofrmEdiModelo.ShowDialog();
            //inicio de edicion
            if (ofrmEdiModelo.Aceptar)
            {
                ModeloD oModeloD = new ModeloD(this.cnx);
                if (oModeloD.editarModelo(ofrmEdiModelo.getModelo()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Modelo editado satisfactoriamente");
                }else
                {
                    MessageBox.Show("Error editando al cliente seleccionado: " + oModeloD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void tpEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.dtModelo.CurrentRow.Index;
            Modelo oModelo = new Modelo(this.dtModelo[0, fila].Value.ToString(), 
                                                                this.dtModelo[1, fila].Value.ToString(), 
                                                                this.dtModelo[2, fila].Value.ToString());

            ModeloD oModeloD = new ModeloD(this.cnx);
            if (oModeloD.eliminaModelo(oModelo))
            {
                this.refrescarGrid();
                MessageBox.Show("Modelo borrado");
            }
            else
            {
                MessageBox.Show("Error eliminando el modelo: " + oModeloD.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //refrescar grid del form
        private void refrescarGrid()
        {
            bool estado = true;
            ModeloD oModeloD = new ModeloD(this.cnx);
            DataSet dsetModelo = oModeloD.obtenerDataSetModelo(ref estado);

            if (estado)
            {
                this.dtModelo.DataSource = dsetModelo.Tables[0];
            }
        }
    }
}
