using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using Entidades;

namespace DAO
{
    public class ClienteD
    {
        //atributos
        private AccesoDatosPostgre conexion;
        private string error;

        //constructor
        public ClienteD(AccesoDatosPostgre conexion)
        {
            this.conexion = conexion;
            this.error = "";
        }

        //get
        public string Error
        {
            get { return error; }
        }

        //metodo insertar nuevo cliente
        public bool agregarCliente(Cliente pCliente)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "insert into cliente(cedula, nombre, ape1, ape2, tel_ofi, tel_casa, cel, fax, direccion)" +
                    "values(@cedula, @nombre, @ape1, @ape2, @tel_ofi, @tel_casa, @cel, @fax, @direccion)";

                NpgsqlParameter[] parametros = new NpgsqlParameter[9];
                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@cedula";
                parametros[0].Value = pCliente.Ced;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@nombre";
                parametros[1].Value = pCliente.Nombre;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@ape1";
                parametros[2].Value = pCliente.Ape1;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[3].ParameterName = "@ape2";
                parametros[3].Value = pCliente.Ape2;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[4].ParameterName = "@tel_ofi";
                parametros[4].Value = pCliente.Tel_ofi;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[5].ParameterName = "@tel_casa";
                parametros[5].Value = pCliente.Tel_casa;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[6].ParameterName = "@cel";
                parametros[6].Value = pCliente.Cel;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[7].ParameterName = "@fax";
                parametros[7].Value = pCliente.Fax;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[8].ParameterName = "@direccion";
                parametros[8].Value = pCliente.Direccion;

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
        public DataSet obtenerDataSetClientes(ref bool estado)
        {
            estado = true;
            DataSet clientes = new DataSet();
            this.error = "";
            try
            {
                string sql = "select *from cliente";
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

        //EDITAR CLIENTES
        public bool editarCliente(Cliente pCliente)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "update cliente set cedula=@cedula, nombre=@nombre, ape1=@ape1, ape2=@ape2, tel_ofi=@tel_ofi, tel_casa=@tel_casa, cel=@cel,  fax =@fax, direccion =@direccion where cedula=@cedula";
                NpgsqlParameter[] parametros = new NpgsqlParameter[9];
                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@cedula";
                parametros[0].Value = pCliente.Ced;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@nombre";
                parametros[1].Value = pCliente.Nombre;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@ape1";
                parametros[2].Value = pCliente.Ape1;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[3].ParameterName = "@ape2";
                parametros[3].Value = pCliente.Ape2;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[4].ParameterName = "@tel_ofi";
                parametros[4].Value = pCliente.Tel_ofi;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[5].ParameterName = "@tel_casa";
                parametros[5].Value = pCliente.Tel_casa;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[6].ParameterName = "@cel";
                parametros[6].Value = pCliente.Cel;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[7].ParameterName = "@fax";
                parametros[7].Value = pCliente.Fax;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[8].ParameterName = "@direccion";
                parametros[8].Value = pCliente.Direccion;

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
        public bool eliminaCliente(Cliente pCliente)
        {
            bool estado = true;
            this.error = "";
            try
            {
                string sql = "delete from cliente where cedula=@cedula";
                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@cedula";
                parametros[0].Value = pCliente.Ced;

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
