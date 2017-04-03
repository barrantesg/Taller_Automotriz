using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using Entidad;
using Datos;

namespace frmFramesProyecto.Vista
{
    public partial class FrmEdiVehiculo : Form
    {
        //atributos
        AccesoDatosPostgre cnx;
        private bool aceptar;

        //get
        public bool Aceptar
        {
            get { return aceptar; }
        }

        public FrmEdiVehiculo(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.aceptar = false;
            //this.llenarComboCliente();
            //this.llenarComboClase();
            //this.llenarComboMarca();
            this.llenarComboCombustible();
        }

        //llenar el combobox con los clientes


        //llenar combobox con combustibles
        private void llenarComboCombustible()
        {
            String[] combustible = { "Regular", "Super", "Diesel", "Electricidad" };
            // cargar los valores por defecto en el combo
            foreach (String item in combustible)
                this.comboCombustible.Items.Add(item.ToString());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
