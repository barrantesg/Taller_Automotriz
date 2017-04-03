using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Datos;
using Entidad;

namespace frmFramesProyecto.Vista
{
    public partial class FrmMarca : Form
    {
        AccesoDatosPostgre cnx;

        public FrmMarca(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.refrescarGrid();
        }

        private void refrescarGrid()
        {
            bool estado = true;
            MarcaD oMarcaD = new MarcaD(this.cnx);
            DataSet dsetMarcas = oMarcaD.obtenerDataSetMarcas(ref estado);

            if (estado)
            {
                this.dtMarcas.DataSource = dsetMarcas.Tables[0];
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEdiMarca ofrmEdiMarca = new FrmEdiMarca();
            ofrmEdiMarca.ShowDialog();
            if (ofrmEdiMarca.Aceptar)
            {
                MarcaD oMarcaD = new MarcaD(this.cnx);
                if (oMarcaD.agregarMarca(ofrmEdiMarca.getMarca()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Marca agregada satisfactoriamente");
                }else
                {
                    MessageBox.Show("Error agregando la marca: " + oMarcaD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int fila = this.dtMarcas.CurrentRow.Index;
            Marca oMarca = new Marca(this.dtMarcas[0, fila].Value.ToString(), this.dtMarcas[1, fila].Value.ToString());

            MarcaD oMarcaD = new MarcaD(this.cnx);
            if (oMarcaD.eliminaMarca(oMarca))
            {
                this.refrescarGrid();
                MessageBox.Show("Marca borrada");
            }else
            {
                MessageBox.Show("Error eliminando la marca: " + oMarcaD.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEdiMarca ofrmEdiMarca = new FrmEdiMarca();
            int fila = this.dtMarcas.CurrentRow.Index;
            ofrmEdiMarca.txtCod.Text = this.dtMarcas[0, fila].Value.ToString();
            ofrmEdiMarca.txtDescripcion.Text = this.dtMarcas[1, fila].Value.ToString();

            ofrmEdiMarca.ShowDialog();
            if (ofrmEdiMarca.Aceptar)
            {
                MarcaD oMarcaD = new MarcaD(this.cnx);
                if (oMarcaD.editarMarca(ofrmEdiMarca.getMarca()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Marca editada satisfactoriamente");
                }else
                {
                    MessageBox.Show("Error editando la marca: " + oMarcaD.Error, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
