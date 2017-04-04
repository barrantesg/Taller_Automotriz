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

namespace GUI
{
    public partial class FrmMarcaModelo : Form
    {
        AccesoDatosPostgre cnx;

        public FrmMarcaModelo(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            FrmMarca ofrmMarca = new FrmMarca(this.cnx);
            ofrmMarca.ShowDialog();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            FrmModelo ofrmModelo = new FrmModelo(this.cnx);
            ofrmModelo.ShowDialog();
        }
    }
}
