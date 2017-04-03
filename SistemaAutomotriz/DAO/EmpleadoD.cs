using Datos;
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
    class EmpleadoD
    {

        private AccesoDatosPostgre conexion;
        private string error;

        public string Error
        {
            get { return error; }
        }

        public EmpleadoD(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.error = "";
        }


        public EmpleadoD()  
        {
        }

        /// <summary> Inserta empleados a la base de datos </summary>
        /// <returns>Retorna el empleado con su respectivo datos</returns>
        public bool InsertaEmpleado(Empleado pEmpleado)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "INSERT INTO empleado(cedula, nombre, apellidouno, apellidodos, telefono, direccion, usuario, contrasena, puesto) VALUES(@A,@B,@C,@D,@E,@F,@G,@H,@I);";
                
                NpgsqlParameter[] parametros = new NpgsqlParameter[9];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@A";
                parametros[0].Value = pEmpleado.Cedula;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[1].ParameterName = "@B";
                parametros[1].Value = pEmpleado.Nombre;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Text; 
                parametros[2].ParameterName = "@C";
                parametros[2].Value = pEmpleado.ApellidoUno;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[3].ParameterName = "@D";
                parametros[3].Value = pEmpleado.ApellidoDos;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[4].ParameterName = "@E";
                parametros[4].Value = pEmpleado.Telefono;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[5].ParameterName = "@F";
                parametros[5].Value = pEmpleado.Direccion;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[6].ParameterName = "@G";
                parametros[6].Value = pEmpleado.Usuario;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[7].ParameterName = "@H";
                parametros[7].Value = pEmpleado.Contrasena;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[8].ParameterName = "@I";
                parametros[8].Value = Int32.Parse(pEmpleado.Puesto);

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


        /// <summary> Verifica el usuario con los usuarios de los empleados de la base de datos /// </summary>
        /// <param name="p">Recibe un empleado</param>
        /// <returns>retorna un empleado</returns>
        public bool Autentificar(Empleado pEmpleado)
        {



            DataSet dsetClientes;
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "SELECT * FROM empleado where usuario = @A and contrasena = @B";


                NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[0].ParameterName = "@A";
                parametros[0].Value = pEmpleado.Usuario.Trim();


                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Text;
                parametros[1].ParameterName = "@B";
                parametros[1].Value = pEmpleado.Contrasena.Trim();


                dsetClientes = this.conexion.ejecutarConsultaSQL(sql,"empleado",parametros);
                   //dsetClientes = this.conexion.ejecutarConsultaSQL(sql);


                if (this.conexion.IsError)
                {
                    estado = false;
                    this.error = this.conexion.ErrorDescripcion;
                }
                else if (dsetClientes.Tables.Count > 0)
                {
                    estado = true;

                }
                else
                    estado = false;

            }

            catch (Exception e)
            {
                estado = false;
                this.error = e.Message;

            }

            return estado;
            
        }

        //obtener datos de la tabla empleados
        public DataSet obtenerDataSetEmpleados(ref bool estado)
        {
            estado = true;
            DataSet clientes = new DataSet();
            this.error = "";
            try
            {
                string sql = "select *from empleado";
                clientes = this.conexion.ejecutarConsultaSQL(sql);
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
            return clientes;
        }

        //EDITAR 
        public bool editarEmpleados(Empleado pEmpleado,Puesto p)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "Update empleado set nombre = @nombre, apellidouno = @apellidouno, apellidodos = @apellidodos, " +
                             "direccion = @direccion, telefono = @telefono, usuario = @usuario, contrasena=@contrasena, puesto =  @puesto " + 
                             "where cedula=@cedula";

                NpgsqlParameter[] parametros = new NpgsqlParameter[9];
                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@cedula";
                parametros[0].Value = pEmpleado.Cedula;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@nombre";
                parametros[1].Value = pEmpleado.Nombre;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@apellidouno";
                parametros[2].Value = pEmpleado.ApellidoUno;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[3].ParameterName = "@apellidodos";
                parametros[3].Value = pEmpleado.ApellidoDos;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[4].ParameterName = "@direccion";
                parametros[4].Value = pEmpleado.Direccion;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[5].ParameterName = "@telefono";
                parametros[5].Value = pEmpleado.Telefono;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[6].ParameterName = "@usuario";
                parametros[6].Value = pEmpleado.Usuario;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[7].ParameterName = "@contrasena";
                parametros[7].Value = pEmpleado.Contrasena;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[8].ParameterName = "@puesto";
                parametros[8].Value = Int32.Parse(pEmpleado.Puesto);


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

        //ELIMINAR CLIENTES DEL SISTEMA
        public bool eliminaEmpleado(Empleado pEmpleado)
        {
            bool estado = true;
            this.error = "";
            try
            {      
                string sql = "DELETE FROM empleado" +
                                " WHERE cedula = @cedula;";

                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@cedula";
                parametros[0].Value = pEmpleado.Cedula;

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
