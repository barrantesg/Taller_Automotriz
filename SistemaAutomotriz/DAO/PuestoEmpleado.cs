using DAO;
using Npgsql;
using NpgsqlTypes;
using SistemaAutomotriz.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.DAO
{
    class PuestoEmpleado
    {
        private AccesoDatosPostgre conexion;
        private string error;

        public string Error
        {
            get { return error; }
        }

        public PuestoEmpleado(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.error = "";
        }


        public PuestoEmpleado()
        {
        }

        /// <summary> Inserta puesto asociados a el empleado en la base de datos </summary>
        /// <returns>Retorna true si se añedio correctamente</returns>
        public bool InsertarPuesto(Empleado pEmpleado, Puesto pPuesto)
        {
            bool estado = true;
            this.error = "";
            try
            {
             string sql = "INSERT INTO puestoEmpleado(id_empleado, puesto, id_puesto)" +
                                 " VALUES(:id_empleado, :puesto, :id_puesto)";

                NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].ParameterName = ":id_empleado";
                    parametros[0].Value = pEmpleado.Cedula;

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Text;
                    parametros[1].ParameterName = ":puesto";
                    parametros[1].Value = pPuesto.Descripcion;

                    parametros[2] = new NpgsqlParameter();
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[2].ParameterName = ":id_puesto";
                    parametros[2].Value = pPuesto.Id;

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
