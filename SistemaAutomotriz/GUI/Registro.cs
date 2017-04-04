using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using SistemaAutomotriz.GUI;
using DAO;

namespace GUI
{
    public partial class FrmRegistro : Form
    {
        AccesoDatosPostgre cnx;

        public FrmRegistro(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente ofrmCliente = new FrmCliente(this.cnx);
            ofrmCliente.ShowDialog();

        }

        private void btnMarcaModelo_Click(object sender, EventArgs e)
        {
            FrmMarcaModelo ofrmMarcaModelo = new FrmMarcaModelo(this.cnx);
            ofrmMarcaModelo.ShowDialog();
            
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            FrmEdiClasesVehiculos ofrmClases = new FrmEdiClasesVehiculos(this.cnx);
            ofrmClases.ShowDialog();
            
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            FrmEdiVehiculo ofrmVehiculos = new FrmEdiVehiculo(this.cnx);
            ofrmVehiculos.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TablaEmpleados tabla = new TablaEmpleados(this.cnx);
            tabla.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            TablaReparaciones tabla = new TablaReparaciones(this.cnx);
            tabla.ShowDialog();
        }
    }
}
