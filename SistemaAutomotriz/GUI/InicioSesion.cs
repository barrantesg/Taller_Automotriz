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
    public partial class InicioSesion : Form
    {
        EmpleadoD eDAO;

  
        public InicioSesion(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            eDAO =  new EmpleadoD(pCnx);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();


               empleado.Usuario = txtUsuario.Text.Trim();
               empleado.Contrasena = txtContrasena.Text.Trim();

            if (eDAO.Autentificar(empleado)) {

                MessageBox.Show("Bienvenido");
            }  else{
                MessageBox.Show("Lo sentimos! No se encuentra registrado en el sistema");
            }
            }


        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }
    }     
          }


 