using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Entidad;

namespace frmFramesProyecto.Vista
{
    public partial class FrmEdiModelo : Form
    {
        //atributos
        AccesoDatosPostgre cnx;
        private bool aceptar;

        //get
        public bool Aceptar
        {
            get { return aceptar; }
        }

        //constructor
        public FrmEdiModelo(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.aceptar = false;
            this.llenarComboMarca();
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


        public string cualMarca
        {
            get { return this.comboMarca.SelectedItem.ToString(); }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.txtDescripcion.Text == "")||
                (this.comboMarca.Text==""))
            {
                MessageBox.Show("Debe llenar todos los datos requeridos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                this.aceptar = true;
                //Marca oMarca = (Marca)this.comboMarca.SelectedItem;
                //Modelo oModelo = new Modelo(this.txtCod.Text, oMarca, this.txtDescripcion.Text);
                
                //MessageBox.Show("Datos almacenados exitosamente");
                this.Close();
            }
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

     

        /*
        public Modelo getModelo()
        {
            Marca oMarca = (Marca)this.comboMarca.SelectedItem;
            string aux = Convert.ToString(oMarca);
            return new Modelo(this.txtCod.Text, aux, this.txtDescripcion.Text);
            //Modelo oModelo = new Modelo(this.txtCod.Text, oMarca, this.txtDescripcion.Text);
            // return oModelo;

        }
        */
        public Modelo getModelo()
        {
            return new Modelo("0", this.comboMarca.Text, this.txtDescripcion.Text);
        }
    }
}
