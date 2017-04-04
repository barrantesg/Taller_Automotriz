using DAO;
using GUI;
using SistemaAutomotriz.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistemaAutomotriz
{
    static class Program
    {

       public static AccesoDatosPostgre cnx;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            //cnx = new AccesoDatosPostgre("postgres", "5432", "Guzman185", "localhost", "Automotriz", "public");

            //if (cnx.IsError)
            //{
            //    MessageBox.Show("Error conectando a base de datos: " +
            //                    cnx.ErrorDescripcion, "Error",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
           
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TablaEmpleados());


            ///




          //  }

       }

    }
}
