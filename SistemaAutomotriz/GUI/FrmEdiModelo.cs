using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Entidades;

namespace GUI
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

        //constructores

        public FrmEdiModelo(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.aceptar = false;
            this.llenarComboMarca();
        }

        public FrmEdiModelo(string pId, string pMarca, string pDesc)
        {
            InitializeComponent();
            this.aceptar = false;
            this.txtCod.Text = pId;
            this.comboMarca.Text = pMarca;
            this.txtDescripcion.Text = pDesc;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.txtCod.Text == "") ||
               (this.txtDescripcion.Text == "") ||
               (this.comboMarca.Text == ""))
            {
                MessageBox.Show("Debe llenar todos los datos requeridos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                this.aceptar = true;
                Marca marcaX = (Marca)this.comboMarca.SelectedItem;
                Modelo oModelo = new Modelo(this.txtCod.Text, marcaX.CodigoMarca, this.txtDescripcion.Text);
                ModeloD oModeloD = new ModeloD(this.cnx);
                oModeloD.agregarModelo(oModelo);

                MessageBox.Show("Datos almacenados exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public Modelo getModelo()
        {
            return new Modelo(this.txtCod.Text, this.comboMarca.Text, this.txtDescripcion.Text);
        }
    }
}
