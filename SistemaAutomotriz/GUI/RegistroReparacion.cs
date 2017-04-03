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
    public partial class RegistroReparacion : Form
    {

        //atributos
        AccesoDatosPostgre cnx;
        private bool aceptar;
       public  int id;

        //get
        public bool Aceptar
        {
            get { return aceptar; }
        }

        ReparacionD rDAO = new ReparacionD();

        public RegistroReparacion(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            cnx = pCnx;
       

        }

        public RegistroReparacion(string pDes, string pHoras, string pCosto)
        {
            InitializeComponent();
            this.aceptar = false;

            this.txtDescripcion.Text = pDes;
            this.txtHoras.Text = pHoras;
            this.txtCosto.Text = pCosto;
            id = 0;

          
        }
        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void RegistroReparacion_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Reparacion reparacion = new Reparacion();

            reparacion.Descripcion = txtDescripcion.Text.Trim();
            reparacion.CantidadHoras = Double.Parse(txtHoras.Text.Trim());
            reparacion.Costo = Double.Parse(txtCosto.Text.Trim());
           

            rDAO.InsertaReparacion(reparacion);
            

            MessageBox.Show("Registro Exitoso");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if ((this.txtDescripcion.Text == "") || (this.txtHoras.Text == "") || (this.txtCosto.Text == ""))
               
            {
                MessageBox.Show("Debe llenar todos los datos requeridos",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.aceptar = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        public Reparacion getReparacion()
        {
            return new Reparacion(id, this.txtDescripcion.Text, Double.Parse(this.txtHoras.Text), Double.Parse(this.txtCosto.Text));      
                
                }
   
    }
}
