using Datos;
using Npgsql;
using SistemaAutomotriz.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.DAO
{
    class PuestoD
    {
        private AccesoDatosPostgre conexion;

        public PuestoD()
        {
        
        }

        public PuestoD(AccesoDatosPostgre conexion2)
        {
            this.conexion = conexion2;
        }

        /// <summary> Carga los puestos de la base de datos </summary>
        /// <returns>retorna un list con los puestos</returns>
        public List<Puesto> CargarPuestos()
        {
            List<Puesto> puestos = new List<Puesto>();
            DataSet dsetClientes= new DataSet();

            string sql ="select id, puesto from puesto";
            dsetClientes = this.conexion.ejecutarConsultaSQL(sql);
            
            foreach (DataRow tupla in dsetClientes.Tables[0].Rows)
            {
                Puesto p = new Puesto(Int16.Parse(tupla["id"].ToString()), tupla["puesto"].ToString());
                puestos.Add(p);
            }
            //while (reader.Read())
            //    {
            //        Puesto p = new Puesto()
            //        {
            //            Id = reader.GetInt32(0),
            //            Descripcion = reader.GetString(1)
            //        };
            //        puestos.Add(p);
            //    }
            
            return puestos;
        }

        //metodo para jalar datos de la tabla marca y mostrarlos en combobox (lista)
        public List<Puesto> obtenerPuestos()
        {
            List<Puesto> puestos = new List<Puesto>();

            using (NpgsqlConnection con = new NpgsqlConnection(this.conexion.conexion.ToString()))
            {
                con.Open();

                string sql = "select id, puesto from puesto";


                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                

                return puestos;


            }
        }
    }

}
