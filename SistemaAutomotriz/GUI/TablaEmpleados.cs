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
    public partial class TablaEmpleados : Form
    {
        AccesoDatosPostgre cnx;

        public TablaEmpleados(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.refrescarGrid();
           
        }
        public TablaEmpleados()
        {
             InitializeComponent();
            this.refrescarGrid();
        }



        private void tpNuevo_Click(object sender, EventArgs e)
        {
           
            RegistroEmpleado ofrmRegistrar = new RegistroEmpleado(this.cnx);
            ofrmRegistrar.ShowDialog();

            if (ofrmRegistrar.Aceptar)
            {
                EmpleadoD oEmpleadoD = new EmpleadoD(this.cnx);
                if (oEmpleadoD.InsertaEmpleado(ofrmRegistrar.getEmpleado()))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Empleado añadido al sistema satisfactoriamente");

                }
                else
                {
                    MessageBox.Show("Error agregando el empleado: " + oEmpleadoD.Error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }

        }


        private void refrescarGrid()
        {
            bool estado = true;
            EmpleadoD oEmpleadoD = new EmpleadoD(this.cnx);
            DataSet dsetEmpleado = oEmpleadoD.obtenerDataSetEmpleados(ref estado);

            if (estado)
            {
                this.dtEmpleados.DataSource = dsetEmpleado.Tables[0];
            }
        }

        private void dtModelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void tpEditar_Click(object sender, EventArgs e)
        {
            EmpleadoD oEmpleadoD = new EmpleadoD(this.cnx);
            RegistroEmpleado ofrmRegistra = new RegistroEmpleado(this.cnx);
            Puesto p = new Puesto();

            //mostrar info de la fila en los respectivos textbox
            int fila = this.dtEmpleados.CurrentRow.Index;
            ofrmRegistra.txtCedula.Text = this.dtEmpleados[0, fila].Value.ToString();
            ofrmRegistra.txtNombre.Text = this.dtEmpleados[1, fila].Value.ToString();
            ofrmRegistra.txtApellidoUno.Text = this.dtEmpleados[2, fila].Value.ToString();
            ofrmRegistra.txtApellidoDos.Text = this.dtEmpleados[3, fila].Value.ToString();
            ofrmRegistra.txtDireccion.Text = this.dtEmpleados[4, fila].Value.ToString();
            ofrmRegistra.txtTelefono.Text = this.dtEmpleados[5, fila].Value.ToString();
            ofrmRegistra.txtUsuario.Text = this.dtEmpleados[6, fila].Value.ToString();
            ofrmRegistra.txtContrasena.Text = this.dtEmpleados[7, fila].Value.ToString();

            ofrmRegistra.cmbPuesto.SelectedText = this.dtEmpleados[8, fila].Value.ToString();
     

            ofrmRegistra.ShowDialog();
            //inicio de edicion
            if (ofrmRegistra.Aceptar)
            {
               
                if (oEmpleadoD.editarEmpleados(ofrmRegistra.getEmpleado(),p))
                {
                    this.refrescarGrid();
                    MessageBox.Show("Empleado editado satisfactoriamente");
                }
            }
                else
                {
                    MessageBox.Show("Error editando al empleado seleccionado: " + oEmpleadoD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        private void tpEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.dtEmpleados.CurrentRow.Index;
            Empleado oEmpleado = new Empleado(this.dtEmpleados[0, fila].Value.ToString(), this.dtEmpleados[1, fila].Value.ToString(),
                this.dtEmpleados[2, fila].Value.ToString(), this.dtEmpleados[3, fila].Value.ToString(), this.dtEmpleados[4, fila].Value.ToString(),
                this.dtEmpleados[5, fila].Value.ToString(), this.dtEmpleados[6, fila].Value.ToString(),
                this.dtEmpleados[7, fila].Value.ToString(), this.dtEmpleados[8, fila].Value.ToString());

            EmpleadoD oEmpleadoD = new EmpleadoD(this.cnx);
            if (oEmpleadoD.eliminaEmpleado(oEmpleado))
            {
                this.refrescarGrid();
                MessageBox.Show("Empleado eliminado satisfactoriamente");
            }
            else
            {
                MessageBox.Show("Error eliminando al empleado: " + oEmpleadoD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }
       
    }
    }
    
