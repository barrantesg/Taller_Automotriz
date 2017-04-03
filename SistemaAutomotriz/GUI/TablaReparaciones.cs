using Datos;
using SistemaAutomotriz.DAO;
using SistemaAutomotriz.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAutomotriz.GUI
{
    public partial class TablaReparaciones : Form
    {
        AccesoDatosPostgre cnx; 

        public TablaReparaciones(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.refrescarGrid();
        }

        private void TablaReparaciones_Load(object sender, EventArgs e)
        {

        }

        private void tpNuevo_Click(object sender, EventArgs e)
        {
            RegistroReparacion ofrmRegistrar = new RegistroReparacion(this.cnx);
            ofrmRegistrar.ShowDialog();

            if (ofrmRegistrar.Aceptar)
            {
                ReparacionD oReparacionD = new ReparacionD(this.cnx);
                if (oReparacionD.InsertaReparacion(ofrmRegistrar.getReparacion()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Reparacion añadido al sistema satisfactoriamente");

                }
                else
                {
                    MessageBox.Show("Error agregando la reparacion: " + oReparacionD.Error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void refrescarGrid()
        {
            bool estado = true;
            ReparacionD oReparacionD = new ReparacionD(this.cnx);
            DataSet dsetReparacion = oReparacionD.obtenerDataSetReparaciones(ref estado);

            if (estado)
            {
                this.dtReparacion.DataSource = dsetReparacion.Tables[0];
            }
        }

        private void tpEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.dtReparacion.CurrentRow.Index;
            Reparacion oReparacion = new Reparacion((int)this.dtReparacion[0, fila].Value, this.dtReparacion[1, fila].Value.ToString(),
               Double.Parse(this.dtReparacion[2, fila].Value.ToString()), Double.Parse(this.dtReparacion[3, fila].Value.ToString()));

            ReparacionD oReparacionD = new ReparacionD(this.cnx);

            if (oReparacionD.eliminaReparacin(oReparacion))
            {
                this.refrescarGrid();
                MessageBox.Show("Reparacion eliminada satisfactoriamente");
            }
            else
            {

                MessageBox.Show("Error eliminando al cliente: " + oReparacionD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tpEditar_Click(object sender, EventArgs e)
        {
            ReparacionD oReparacionD = new ReparacionD(this.cnx);
            RegistroReparacion ofrmRegistra = new RegistroReparacion(this.cnx);

            //mostrar info de la fila en los respectivos textbox
            int fila = this.dtReparacion.CurrentRow.Index;

            ofrmRegistra.id= Int32.Parse(this.dtReparacion[0, fila].Value.ToString());
            ofrmRegistra.txtDescripcion.Text =this.dtReparacion[1, fila].Value.ToString();
            ofrmRegistra.txtHoras.Text = this.dtReparacion[2, fila].Value.ToString();
            ofrmRegistra.txtCosto.Text = this.dtReparacion[3, fila].Value.ToString();
            
            //ofrmRegistra.txtObservaciones.Text = this.dtReparacion[3, fila].Value.ToString();

            ofrmRegistra.ShowDialog();
            //inicio de edicion
            if (ofrmRegistra.Aceptar)
            {

                if (oReparacionD.editarReparacion(ofrmRegistra.getReparacion()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Reparacion editado satisfactoriamente");
                }
            }
            else
            {
                MessageBox.Show("Error editando la reparacion seleccionado: " + oReparacionD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

