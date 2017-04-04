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
using DAO;
using Entidades;

namespace GUI
{
    public partial class FrmEdiClasesVehiculos : Form
    {
        //atributos
        AccesoDatosPostgre cnx;
        private bool aceptar;
       
        //get
        public bool Aceptar
        {
            get { return aceptar; }
        }
        public FrmEdiClasesVehiculos(AccesoDatosPostgre pCnx)
        {
            InitializeComponent();
            this.cnx = pCnx;
            this.refrescarGrid();
        }

        private void refrescarGrid()
        {
            //bool estado = true;
            //ModeloD oModelo = new ModeloD(this.cnx);
            //DataSet dsetClases = oModelo.obtenerDataSetClase(ref estado);

            //if (estado)
            //{
            //    this.dtClases.DataSource = dsetClases.Tables[0];
            //}
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        //    if (this.txtClase.Text == "")
        //    {
        //        MessageBox.Show("Debe llenar todos los datos requeridos",
        //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }else
        //    {
        //        this.aceptar = true;
        //        //this.Close();
                
        //    }
        //    if (this.aceptar)
        //    {
        //        ModeloD oClaseD = new ModeloD(this.cnx);
        //        if (oClaseD.agregarClase(this.getClase()))
        //        {
        //            this.refrescarGrid();
        //            MessageBox.Show("Clase agregada satisfactoriamente");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error agregando la clase: " + oClaseD.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    this.txtClase.Clear();
        }

        //public Mdelo getClase()
        //{
        //    return new Modelo(this.txtClase.Text);
        //}
      
        ////eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
        //    int fila = this.dtClases.CurrentRow.Index;
        //    Clase oClase = new Clase(Convert.ToInt32(this.dtClases[0, fila].Value.ToString()), this.dtClases[1, fila].Value.ToString());

        //    ModeloD oModeloD = new ModeloD(this.cnx);
        //    if (oClaseD.eliminaMarca(oClase))
        //    {
        //        this.refrescarGrid();
        //        MessageBox.Show("Clase borrada");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error eliminando la marca: " + oClaseD.Error, "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        ////Editar
        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    //int fila = this.dtClases.CurrentRow.Index;
        //    //this.txtClase.Text = this.dtClases[1, fila].Value.ToString();
        //    //if (this.aceptar)
        //    //{
        //    //    ClaseD oClaseD = new ClaseD(this.cnx);
        //    //    if (oClaseD.editarClase(this.getClase()))
        //    //    {
        //    //        this.refrescarGrid();
        //    //        this.txtClase.Clear();
        //    //        MessageBox.Show("Clase editada satisfactoriamente");
        //    //    }
        //    //    else
        //    //    {
        //    //        MessageBox.Show("Error editando la marca: " + oClaseD.Error, "Error",
        //    //           MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
            }
        
   // }
//}
