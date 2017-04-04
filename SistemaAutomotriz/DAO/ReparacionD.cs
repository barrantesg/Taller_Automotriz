using DAO;
using Npgsql;
using NpgsqlTypes;
using SistemaAutomotriz.DAO;
using SistemaAutomotriz.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.DAO
{
    class ReparacionD
    {
        private AccesoDatosPostgre conexion;
        private string error;

        public string Error
        {
            get { return error; }
        }

        public ReparacionD(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.error = "";
        }


        public ReparacionD()
        {
        }

        /// <summary> Inserta repraciones a la base de datos </summary>
        /// <returns>Retorna el reparaciones con su respectivo datos</returns>
        public bool InsertaReparacion(Reparacion pReparacion)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "INSERT INTO reparacion(descripcion, cantidadhoras, costo)" +
                 "VALUES(:A,:B,:C);";

                NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[0].ParameterName = "@A";
                parametros[0].Value = pReparacion.Descripcion;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Numeric;
                parametros[1].ParameterName = "@B";
                parametros[1].Value = pReparacion.CantidadHoras;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Numeric;
                parametros[2].ParameterName = "@C";
                parametros[2].Value = pReparacion.Costo;


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
       

        //obtener datos de la tabla cliente
        public DataSet obtenerDataSetReparaciones(ref bool estado)
       {
            estado = true;
            DataSet reparaciones = new DataSet();
            this.error = "";
            try
            {
                string sql = "select * from reparacion";

                //  string sql = "select *from empleado";
                reparaciones = this.conexion.ejecutarConsultaSQL(sql);
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
            return reparaciones;

        }

        /// <summary> Elimina repraciones a la base de datos </summary>
        /// <returns>Retorna true si fue eliminada con exito</returns>
        public bool eliminaReparacin(Reparacion pReparacion)
        {
            bool estado = true;
            this.error = "";
            try
            {

                string sql = "DELETE FROM reparacion where id=@id;";

                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@id";
                parametros[0].Value = pReparacion.Id;

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

        /// <summary> Actualiza repraciones a la base de datos </summary>
        /// <returns>Retorna true si fue eliminada con exito</returns>
        public bool editarReparacion(Reparacion pReparacion)
        {
            bool estado = true;
            this.error = "";
            try  
            {
                string sql = "update reparacion set id=@id, descripcion=@descripcion, cantidadhoras=@horas, costo=@costo where id=@id";
            
               NpgsqlParameter[] parametros = new NpgsqlParameter[4];

                
                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@id";
                parametros[0].Value = pReparacion.Id;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[1].ParameterName = "@descripcion";
                parametros[1].Value = pReparacion.Descripcion;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Numeric;
                parametros[2].ParameterName = "@horas"; 
                parametros[2].Value = pReparacion.CantidadHoras;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Numeric; 
                parametros[3].ParameterName = "@costo";
                parametros[3].Value = pReparacion.Costo;
                

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
