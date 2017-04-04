using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Data;
using Entidades;
using Npgsql;
using DAO;
using Entidades;

namespace DAO
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
                get { return error; }
            }

            public string ErrorMsg
            {
                get { return errorMsg; }
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
                DataSet modelo = new DataSet();
                this.errorMsg = "";
                try
                {
                    string sql = "select * from modelo";
                    modelo = this.conexion.ejecutarConsultaSQL(sql);
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
                return modelo;
            }

            //metodo para jalar datos de la tabla marca y mostrarlos en combobox (lista)
            public List<Marca> obtenerMarcas()
            {
                this.limpiarError();
                List<Marca> marcas = new List<Marca>();
                DataSet dsetMarcas;
                string sql = "select * from marca";
                dsetMarcas = this.conexion.ejecutarConsultaSQL(sql);
                foreach (DataRow tupla in dsetMarcas.Tables[0].Rows)
                {
                    Marca oMarca = new Marca(tupla["marca"].ToString(), tupla["descripcion"].ToString());
                    marcas.Add(oMarca);
                }
                return marcas;
            }

            //agregar modelo nuevo
            public bool agregarModelo(Modelo pModelo)
            {
                bool estado = true;
                this.errorMsg = "";
                try
                {
                    string sql = "insert into modelo(idmodelo, desc_marca, descripcion)" +
                        "values(@idmodelo,@desc_marca,@descripcion); ";

                    NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
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

            //editar
            public bool editarModelo(Modelo pModelo)
            {
                bool estado = true;
                this.errorMsg = "";
                try
                {

                    string sql = "update modelo set idmodelo=@idmodelo, desc_marca=@desc_marca,  descripcion=@descripcion where idmodelo=@idmodelo";

                    NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
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
                    string sql = "delete from modelo where idmodelo=@idmodelo";
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
                    this.errorMsg = e.Message;
                }
                return estado;
            }

            //obtener modelos x marca
            public List<Modelo> obtenerModelos(Marca pMarca)
            {
                this.limpiarError();
                List<Modelo> modelos = new List<Modelo>();
                DataSet dsetModelos;
                //string sql = "select mo.idmodelo, mo.descripcion, mo.marca from modelo mo, marca ma" +
                //" where mo.desc_marca=ma.marca";
                string sql = "select  mo.idmodelo, mo.descripcion from modelo mo, marca ma" +
                    " where mo.desc_marca=ma.marca";
                try
                {
                    if (pMarca != null)
                    {
                        sql += " and ma.marca=@marca";
                        Parametro oParametro = new Parametro();
                        oParametro.agregarParametro("@marca", NpgsqlDbType.Varchar, pMarca.CodigoMarca);
                        dsetModelos = this.conexion.ejecutarConsultaSQL(sql, "modelo", oParametro.obtenerParametros());

                    }
                    else
                    {
                        dsetModelos = this.conexion.ejecutarConsultaSQL(sql);
                    }
                    foreach (DataRow tupla in dsetModelos.Tables[0].Rows)
                    {
                        Marca oMarca = new Marca(tupla["descripcion"].ToString());
                        Modelo oModelo = new Modelo(tupla["idmodelo"].ToString(), tupla["descripcion"].ToString());
                        modelos.Add(oModelo);
                    }

                }
                catch (Exception e)
                {
                    this.errorMsg = e.Message;
                }
                return modelos;
            }
        }
}
