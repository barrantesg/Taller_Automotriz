using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System.Data;
namespace Datos
{
    public class MarcaD
    {
        private AccesoDatosPostgre conexion;
        private string error;

        public string Error
        {
            get { return error; }
        }

        public MarcaD(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.error="";
        }

        //agregar a marca
        public bool agregarMarca(Marca pMarca)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "insert into marca(id, descripcion) values (@marca,@descripcion)";
                NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@marca";
                parametros[0].Value = pMarca.CodigoMarca;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@descripcion";
                parametros[1].Value = pMarca.DescMarca;

                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.error = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.error = e.Message;
            }
            return estado;
        }

        //obtener datos de tabla marca
        public DataSet obtenerDataSetMarcas(ref bool estado)
        {
            estado = true;
            DataSet marcas = new DataSet();
            this.error = "";
            try
            {
                string sql = "select * from marca";
                marcas = this.conexion.ejecutarConsultaSQL(sql);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.error = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.error = e.Message;
            }
            return marcas;
        }
        
        //eliminar datos de tabla marca
        public bool eliminaMarca(Marca pMarca)
        {

            bool estado = true;
            this.error = "";
            try
            {
                string sql = "delete from marca where id=@marca";
                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@marca";
                parametros[0].Value = pMarca.CodigoMarca;


                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.error = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.error = e.Message;
            }
            return estado;
        }

        //editar tabla marca
        public bool editarMarca(Marca pMarca)
        {
            bool estado = true;
            this.error = "";
            try
            {

                string sql = "update marca set id=@marca, descripcion=@descripcion where id= @marca";

                NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@marca";
                parametros[0].Value = pMarca.CodigoMarca;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@descripcion";
                parametros[1].Value = pMarca.DescMarca;

                this.conexion.ejecutarSQL(sql, parametros);
                if (this.conexion.IsError)
                {
                    estado = false;
                    this.error = this.conexion.ErrorDescripcion;
                }
            }
            catch (Exception e)
            {
                estado = false;
                this.error = e.Message;
            }
            return estado;

        }
    }
}
