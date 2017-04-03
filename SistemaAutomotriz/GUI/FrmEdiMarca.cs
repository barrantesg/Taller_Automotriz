using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;

namespace frmFramesProyecto.Vista
{
    public partial class FrmEdiMarca : Form
    {
        private bool aceptar;

        public bool Aceptar
        {
            get { return aceptar; }
        }

        public FrmEdiMarca()
        {
            InitializeComponent();
            this.aceptar = false;
        }

        public FrmEdiMarca(string pCodigo, string pDescripcion)
        {
            InitializeComponent();
            this.aceptar = false;
            this.txtCod.Text = pCodigo;
            this.txtDescripcion.Text = pDescripcion;
        }
        private void FrmEdiMarca_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.txtCod.Text=="")||(this.txtDescripcion.Text==""))
            {
                MessageBox.Show("Debe llenar todos los datos requeridos",
                    "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
            {
                this.aceptar = true;
                this.Close();
            }
        }

        public Marca getMarca()
        {
            return new Marca(this.txtCod.Text, this.txtDescripcion.Text);
        }
    }
}
