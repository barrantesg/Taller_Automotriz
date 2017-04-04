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


namespace GUI
{
    public partial class FrmEdiCliente : Form
    {
        private bool aceptar;

        public FrmEdiCliente()
        {
            InitializeComponent();
            this.aceptar = false;
        }

        public bool Aceptar
        {
            get { return aceptar; }
        }

        public FrmEdiCliente(string pCed, string pNombre, string pApe1, string pApe2, string pOfi, string pCasa, string pCel,string pFax, string pDire)
        {
            InitializeComponent();
            this.aceptar = false;
            this.txtCed.Text = pCed;
            this.txtNombre.Text = pNombre;
            this.txtApe1.Text = pApe1;
            this.txtApe2.Text = pApe2;
            this.txtOfi.Text = pOfi;
            this.txtCasa.Text = pCasa;
            this.txtCel.Text = pCel;
            this.txtFax.Text = pFax;
            this.txtDire.Text = pDire;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.txtCed.Text == "") || (this.txtNombre.Text == "") || (this.txtApe1.Text == "") || (this.txtApe2.Text == "")
                || (this.txtOfi.Text == "") || (this.txtCasa.Text=="")|| (this.txtCel.Text == "") || (this.txtFax.Text == "") || (this.txtDire.Text == ""))
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

        public Cliente getCliente()
        {
            return new Cliente(this.txtCed.Text, this.txtNombre.Text, this.txtApe1.Text, this.txtApe2.Text,
                 this.txtOfi.Text, this.txtCasa.Text, this.txtCel.Text, this.txtFax.Text, this.txtDire.Text);
        }
    }
}
