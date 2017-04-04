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
using Entidades;
using DAO;

namespace GUI
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
            this.llenarComboCliente();
            this.llenarComboClase();
            this.llenarComboMarca();
            this.llenarComboCombustible();
            this.refrescarGrid();
        }

        //refrescar grid
        private void refrescarGrid()
        {
            bool estado = true;
            VehiculoD oVehiculoD = new VehiculoD(this.cnx);
            DataSet dsetVehiculos = oVehiculoD.obtenerDataSetVehiculo(ref estado);

            if (estado)
            {
                this.dtVehiculo.DataSource = dsetVehiculos.Tables[0];
            }
        }
        #region metodos para cargar los combobox
        //llenar el combobox con los clientes
        public void llenarComboCliente()
        {
            this.comboCliente.Items.Clear();
            VehiculoD oVehiculoD = new VehiculoD(this.cnx);
            List<Cliente> clientes = oVehiculoD.obtenerClientes();

            foreach (Cliente oMarcaL in clientes)
            {
                this.comboCliente.Items.Add(oMarcaL);
            }

        }

        //llenar el combobox con  las clases
        public void llenarComboClase()
        {
            this.comboClase.Items.Clear();
            VehiculoD oVehiculoD = new VehiculoD(this.cnx);
            List<Clase> clases = oVehiculoD.obtenerClase();

            foreach (Clase ClaseL in clases)
            {
                this.comboClase.Items.Add(ClaseL);
            }

        }

        //llenar el combobox con las marcas
        public void llenarComboMarca()
        {
            this.comboMarca.Items.Clear();
            ModeloD oModeloD = new ModeloD(this.cnx);
            List<Marca> marcas = oModeloD.obtenerMarcas();

            foreach (Marca oMarcaL in marcas)
            {
                this.comboMarca.Items.Add(oMarcaL);
            }

        }

        //llenar combobox con los modelos
        public void llenarComboModelo(Marca pMarca)
        {
            this.comboModelo.Items.Clear();
            ModeloD oModeloD = new ModeloD(this.cnx);
            List<Modelo> modelos = oModeloD.obtenerModelos(pMarca);
            foreach (Modelo oModeloL in modelos)
            {
                this.comboModelo.Items.Add(oModeloL);
            }
        }

        //llenar combobox con combustibles
        private void llenarComboCombustible()
        {
            String[] combustible = { "Regular", "Super", "Diesel", "Electricidad" };
            // cargar los valores por defecto en el combo
            foreach (String item in combustible)
                this.comboCombustible.Items.Add(item.ToString());
        }

        #endregion


        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((this.txtAño.Text == "") || (this.txtCapacidad.Text == "") || (this.txtChasis.Text == "") || (this.txtCilindraje.Text == "")
              || (this.txtMotor.Text == "") || (this.txtPlaca.Text == "") || (this.comboClase.Text == "") || (this.comboCliente.Text == "")
              || (this.comboCombustible.Text == "") || (this.comboMarca.Text == "") || (this.comboModelo.Text == ""))
            {
                MessageBox.Show("Debe llenar todos los datos requeridos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.aceptar = true;

                if (aceptar)
                {
                    //convertir los items seleccionados de los combos
                    Clase claseX = (Clase)this.comboClase.SelectedItem;
                    string combustibleX = Convert.ToString(this.comboCombustible.SelectedItem);
                    Cliente clienteX = (Cliente)this.comboCliente.SelectedItem;
                    Marca marcaX = (Marca)this.comboMarca.SelectedItem;
                    Modelo modeloX = (Modelo)this.comboModelo.SelectedItem;
                    //llamamos a l entidad encargada de recibir los parametros
                    VehiculoD oVehiculoD = new VehiculoD(this.cnx);
                    Vehiculo oVehiculo = new Vehiculo(this.txtAño.Text, this.txtCapacidad.Text, this.txtChasis.Text,
                    this.txtCilindraje.Text, claseX.Id, combustibleX, this.txtMotor.Text, this.txtPlaca.Text, clienteX.Ced,
                    marcaX.CodigoMarca, modeloX.Id);
                    //hacemos llamado a datos para realizar la insercion

                    oVehiculoD.agregarVehiculo(oVehiculo);
                    this.refrescarGrid();
                    MessageBox.Show("Vehículo agregado satisfactoriamente");
                }

                this.refrescarGrid();
                this.limpiarCajillas();
            }
        }

        public void limpiarCajillas()
        {
            this.txtAño.Clear();
            this.txtCapacidad.Clear();
            this.txtChasis.Clear();
            this.txtCilindraje.Clear();
            this.llenarComboCombustible();
            this.llenarComboClase();
            this.llenarComboCliente();
            this.llenarComboMarca();
            this.txtMotor.Clear();
            this.txtPlaca.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.dtVehiculo.CurrentRow.Index;
            Vehiculo oVehiculo = new Vehiculo(
                this.dtVehiculo[0, fila].Value.ToString(),
                this.dtVehiculo[1, fila].Value.ToString(),
                this.dtVehiculo[2, fila].Value.ToString(),
                this.dtVehiculo[3, fila].Value.ToString(),
                Convert.ToInt32(this.dtVehiculo[4, fila].Value.ToString()),
                this.dtVehiculo[5, fila].Value.ToString(),
                this.dtVehiculo[6, fila].Value.ToString(),
                this.dtVehiculo[7, fila].Value.ToString(),
                this.dtVehiculo[8, fila].Value.ToString(),
                this.dtVehiculo[9, fila].Value.ToString(),
                this.dtVehiculo[10, fila].Value.ToString());

            VehiculoD oVehiculoD = new VehiculoD(this.cnx);
            oVehiculo.Id = Convert.ToInt32(this.dtVehiculo[0, fila].Value.ToString());
            if (oVehiculoD.eliminaVehiculo(oVehiculo))
            {
                this.refrescarGrid();
                MessageBox.Show("Vehículo eliminado");
            }
            else
            {
                MessageBox.Show("Error eliminando el vehículo: " + oVehiculoD.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Vehiculo getVehiculo()
        {
            return new Vehiculo(this.txtAño.Text, this.txtCapacidad.Text, this.txtChasis.Text, this.txtCilindraje.Text,
                this.comboClase.SelectedIndex, this.comboCombustible.Text, this.txtMotor.Text, this.txtPlaca.Text,
                this.comboCliente.Text, this.comboMarca.Text, this.comboModelo.Text);
        }
    }
}
