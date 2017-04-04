using DAO;
using Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VehiculoD
    {
        //atributos
        private AccesoDatosPostgre conexion;
        private bool error;
        private string errorMsg;

        //get
        public bool Error
        {
            get { return error; }
        }

        public string ErrorMsg
        {
            get { return errorMsg; }
        }

        //constructor
        public VehiculoD(AccesoDatosPostgre pConexion)
        {
            this.conexion = pConexion;
            this.limpiarError();
        }

        private void limpiarError()
        {
            this.error = false;
            this.errorMsg = "";
        }

        //obtener datos de la tabla cliente y mostrarlos en combobox (lista)
        public List<Cliente> obtenerClientes()
        {
            this.limpiarError();
            List<Cliente> clientes = new List<Cliente>();
            DataSet dsetClientes;
            //string sql = "select nombre, ape1,ape2,cel from cliente";
            string sql = "select cedula from cliente";
            dsetClientes = this.conexion.ejecutarConsultaSQL(sql);
            foreach (DataRow tupla in dsetClientes.Tables[0].Rows)
            {
                Cliente oCliente = new Cliente(tupla["cedula"].ToString());
                clientes.Add(oCliente);
            }
            return clientes;
        }

        //obtener datos de marca y mostrarlos en combobox
        public List<Marca> obtenerMarcas()
        {
            this.limpiarError();
            List<Marca> marcas = new List<Marca>();
            DataSet dsetMarcas;
            string sql = "select descripcion from marca";
            dsetMarcas = this.conexion.ejecutarConsultaSQL(sql);
            foreach (DataRow tupla in dsetMarcas.Tables[0].Rows)
            {
                Marca oMarca = new Marca(tupla["descripcion"].ToString());
                marcas.Add(oMarca);
            }
            return marcas;
        }

        //obtener datos de clase
        public List<Clase> obtenerClase()
        {
            this.limpiarError();
            List<Clase> marcas = new List<Clase>();
            DataSet dsetClase;
            string sql = "select * from clase";
            dsetClase = this.conexion.ejecutarConsultaSQL(sql);
            foreach (DataRow tupla in dsetClase.Tables[0].Rows)
            {
                Clase oClase = new Clase(Convert.ToInt32(tupla["clase"].ToString()), tupla["descripcion"].ToString());
                marcas.Add(oClase);
            }
            return marcas;
        }

        //obtener datos de modelos 
        public List<Modelo> obtenerModelo()
        {
            this.limpiarError();
            List<Modelo> marcas = new List<Modelo>();
            DataSet dsetModelo;
            string sql = "select descripcion from modelo";
            dsetModelo = this.conexion.ejecutarConsultaSQL(sql);
            foreach (DataRow tupla in dsetModelo.Tables[0].Rows)
            {
                Modelo oModelo = new Modelo(tupla["descripcion"].ToString());
                marcas.Add(oModelo);
            }
            return marcas;
        }

        //mostrar datos en el grid
        public DataSet obtenerDataSetVehiculo(ref bool estado)
        {
            estado = true;
            DataSet vehiculo = new DataSet();
            this.errorMsg = "";
            try
            {
                string sql = "select * from vehiculo";
                vehiculo = this.conexion.ejecutarConsultaSQL(sql);
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
            return vehiculo;
        }

        //agregar al sistema
        public bool agregarVehiculo(Vehiculo pVehiculo)
        {
            bool estado = true;
            this.errorMsg = "";
            try
            {
                string sql = "insert into vehiculo ( anio, capacidad, chasis, cilindraje, idclase, combustible," +
                    "motor, placa, idcliente, idmarca, idmodelo)" +
                    "values (@anio, @capacidad, @chasis, @cilindraje,@idclase, @combustible, @motor, @placa, @idcliente, @idmarca,@idmodelo)";
                NpgsqlParameter[] parametros = new NpgsqlParameter[11];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@anio";
                parametros[0].Value = pVehiculo.AñoProd;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@capacidad";
                parametros[1].Value = pVehiculo.Capacidad;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@chasis";
                parametros[2].Value = pVehiculo.Chasis;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[3].ParameterName = "@cilindraje";
                parametros[3].Value = pVehiculo.Cilindraje;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[4].ParameterName = "@idclase";
                parametros[4].Value = pVehiculo.Clase;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[5].ParameterName = " @combustible";
                parametros[5].Value = pVehiculo.Combustible;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[6].ParameterName = "@motor";
                parametros[6].Value = pVehiculo.Motor;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[7].ParameterName = " @placa";
                parametros[7].Value = pVehiculo.Placa;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[8].ParameterName = "@idcliente";
                parametros[8].Value = pVehiculo.OCliente;

                parametros[9] = new NpgsqlParameter();
                parametros[9].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[9].ParameterName = "@idmarca";
                parametros[9].Value = pVehiculo.OMarca;

                parametros[10] = new NpgsqlParameter();
                parametros[10].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[10].ParameterName = "@idmodelo";
                parametros[10].Value = pVehiculo.OModelo;

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

        //eliminar de la BD
        public bool eliminaVehiculo(Vehiculo pVehiculo)
        {
            bool estado = true;
            this.errorMsg = "";
            try
            {
                string sql = "delete from vehiculo where idvehiculo=@idvehiculo";
                NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[0].ParameterName = "@idvehiculo";
                parametros[0].Value = pVehiculo.Id;

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

        //editar la BD
        public bool editarVehiculo(Vehiculo pVehiculo)
        {
            bool estado = true;
            this.errorMsg = "";
            try
            {

                string sql = "update vehiculo set idvehiculo=@idvehiculo, anio=@, capacidad=@capacidad, " +
                    "chasis=@chasis, cilindraje=@cilindraje, idclase=@idclase, combustible=@combustible, " +
                    "motor=@motor, placa=@placa, idcliente=@idcliente, idmarca=@idmarca, idmodelo=@idmodelo " +
                    "where idvehiculo= @idvehiculo";
                NpgsqlParameter[] parametros = new NpgsqlParameter[11];

                parametros[0] = new NpgsqlParameter();
                parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[0].ParameterName = "@anio";
                parametros[0].Value = pVehiculo.AñoProd;

                parametros[1] = new NpgsqlParameter();
                parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[1].ParameterName = "@capacidad";
                parametros[1].Value = pVehiculo.Capacidad;

                parametros[2] = new NpgsqlParameter();
                parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[2].ParameterName = "@chasis";
                parametros[2].Value = pVehiculo.Chasis;

                parametros[3] = new NpgsqlParameter();
                parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[3].ParameterName = "@cilindraje";
                parametros[3].Value = pVehiculo.Cilindraje;

                parametros[4] = new NpgsqlParameter();
                parametros[4].NpgsqlDbType = NpgsqlDbType.Integer;
                parametros[4].ParameterName = "@idclase";
                parametros[4].Value = pVehiculo.Clase;

                parametros[5] = new NpgsqlParameter();
                parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[5].ParameterName = " @combustible";
                parametros[5].Value = pVehiculo.Combustible;

                parametros[6] = new NpgsqlParameter();
                parametros[6].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[6].ParameterName = "@motor";
                parametros[6].Value = pVehiculo.Motor;

                parametros[7] = new NpgsqlParameter();
                parametros[7].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[7].ParameterName = " @placa";
                parametros[7].Value = pVehiculo.Placa;

                parametros[8] = new NpgsqlParameter();
                parametros[8].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[8].ParameterName = "@idcliente";
                parametros[8].Value = pVehiculo.OCliente;

                parametros[9] = new NpgsqlParameter();
                parametros[9].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[9].ParameterName = "@idmarca";
                parametros[9].Value = pVehiculo.OMarca;

                parametros[10] = new NpgsqlParameter();
                parametros[10].NpgsqlDbType = NpgsqlDbType.Varchar;
                parametros[10].ParameterName = "@idmodelo";
                parametros[10].Value = pVehiculo.OModelo;

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
    }
}
