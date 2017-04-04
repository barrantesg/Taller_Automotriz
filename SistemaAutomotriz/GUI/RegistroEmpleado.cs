using DAO;
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
    public partial class RegistroEmpleado : Form
    {
        //EmpleadoD eDAO = new EmpleadoD();
        PuestoD pDAO = new PuestoD();

        //atributos
        AccesoDatosPostgre cnx;
        private bool aceptar;

        //get
        public bool Aceptar
        {
            get { return aceptar; }
        }


        public RegistroEmpleado(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            cnx = pCnx;
           
            this.llenarComboPuestos();
           

        }
        public RegistroEmpleado(string pCed, string pNombre, string pApe1, string pApe2, string pOfi, string pDire, string direccion, string usuario, string contrasena, string puesto)
        {
            InitializeComponent();
            this.aceptar = false;
            this.txtCedula.Text = pCed;
            this.txtNombre.Text = pNombre;
            this.txtApellidoUno.Text = pApe1;
            this.txtApellidoDos.Text = pApe2;
            this.txtTelefono.Text = pOfi;            
            this.txtDireccion.Text = pDire;
            this.txtUsuario.Text = usuario;
            this.txtContrasena.Text = contrasena;
            this.cmbPuesto.SelectedText = puesto;
           

        }

        /// <summary> LLena el comboBox con los puestos de la base de datos </summary>
        public void llenarComboPuestos()
        {
            this.cmbPuesto.Items.Clear();
            
            PuestoD oPuestoD = new PuestoD(cnx);
            List<Puesto> puestos = oPuestoD.CargarPuestos();
            
            foreach (Puesto oPuesto in puestos)
            {
                this.cmbPuesto.Items.Add(oPuesto);
            }
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((this.txtCedula.Text == "") || (this.txtNombre.Text == "") || (this.txtApellidoUno.Text == "") || (this.txtApellidoDos.Text == "")
                   || (this.txtTelefono.Text == "")  || (this.txtDireccion.Text == "") || (this.txtUsuario.Text == "") || (this.txtContrasena.Text == ""))
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistroEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public Empleado getEmpleado()
        {
            return new Empleado(this.txtCedula.Text, this.txtNombre.Text, this.txtApellidoUno.Text, this.txtApellidoDos.Text, this.txtTelefono.Text, this.txtDireccion.Text, this.txtUsuario.Text, this.txtContrasena.Text, this.cmbPuesto.SelectedIndex.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
