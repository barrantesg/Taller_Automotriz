using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Data;
using Entidad;
using Npgsql;

namespace Datos
{

    public class ModeloD
    {
        //atributos
        private AccesoDatosPostgre conexion;
        private bool error;
        private string errorMsg;

        //get
        public bool Error
        {
            get {return error;}
        }

        public string ErrorMsg
        {
            get{ return errorMsg;}
        }

        public ModeloD(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.limpiarError();
        }

        private void limpiarError()
        {
            this.error = false;
            this.errorMsg = "";
        }

        //dataset para mostrar datos en grid obtener datos de tabla modelo
        public DataSet obtenerDataSetModelo(ref bool estado)
        {
            estado = true;
            DataSet marcas = new DataSet();
            this.errorMsg = "";
            try
            {
                string sql = "select * from modelo";
                marcas = this.conexion.ejecutarConsultaSQL(sql);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.errorMsg = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.errorMsg = e.Message;
            }
            return marcas;
        }

        //metodo para jalar datos de la tabla marca y mostrarlos en combobox (lista)
        public List<Marca> obtenerMarcas()
        {

            this.limpiarError();
            List<Marca> marcas = new List<Marca>();
            DataSet dsetMarcas;
            string sql = "select  descripcion from marca";
            dsetMarcas= this.conexion.ejecutarConsultaSQL(sql);
            foreach(DataRow tupla in dsetMarcas.Tables[0].Rows)
            {
                Marca oMarca = new Marca(tupla["descripcion"].ToString());
                marcas.Add(oMarca);
            }
            return marcas;
            
            
        }

        public int obtenerMarcaID(string n)
        {

            int pos = 0;

            this.limpiarError();
            Marca m = new Marca();
           
            

            try
            {


                string sql = @"select 
                                descripcion
                               from 
                                marca" + " WHERE descripcion=:d;";



                NpgsqlCommand cmd = new NpgsqlCommand(sql, this.conexion.conexion);
     
                cmd.Parameters.AddWithValue("d", n.Trim());

                pos = (int)(cmd.ExecuteScalar());


            }
           
            catch (Exception e)
            {
             
                this.errorMsg = e.Message;
            }

            return pos;


        }




        //agregar modelo nuevo
        public bool agregarModelo(Modelo pModelo)
        {
            bool estado = true;
            this.errorMsg = "";
            int id = obtenerMarcaID(pModelo.Marca);
            try
            {
                string sql = "insert into modelo(descripcion, id_marca)" +
                    "values (@desc_marca, @id_marca)";

                NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@desc_marca";
                parametros[0].Value = pModelo.Descripcion;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[1].ParameterName = "@id_marca";
                parametros[1].Value = id;

                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.errorMsg = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.errorMsg = e.Message;
            }
            return estado;
        }

        //editar
        public bool editarModelo(Modelo pModelo)
        {
            bool estado = true;
            this.errorMsg = "";
            try
            {
               

                string sql = "update modelo set id=@idmodelo, descripcion=@desc_marca,  id_marca=@descripcion where id=@idmodelo";

                NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@idmodelo";
                parametros[0].Value = pModelo.Id;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@desc_marca";
                parametros[1].Value = pModelo.Marca;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@descripcion";
                parametros[2].Value = pModelo.Descripcion;

                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.errorMsg = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.errorMsg = e.Message;
            }
            return estado;

        }
        
        //eliminar datos de tabla modelo
        public bool eliminaModelo(Modelo pModelo)
        {

            bool estado = true;
            this.errorMsg = "";
            try
            {
                string sql = "delete from modelo where id=@idmodelo";
                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@idmodelo";
                parametros[0].Value = pModelo.Id;

                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.errorMsg = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.errorMsg= e.Message;
            }
            return estado;
        }
       
    }
}
