using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.Entidades
{
    public class Empleado
    {
        private string cedula;
        private string nombre;
        private string apellidoUno;
        private string apellidoDos;
        private string telefono;
        private string direccion;
        private string usuario;
        private string contrasena;
        private string puesto;

        public Empleado(string cedula, string nombre, string apellidoUno, string apellidoDos, string telefono, string direccion, string usuario, string contrasena, string puesto)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidoUno = apellidoUno;
            this.apellidoDos = apellidoDos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.puesto = puesto;
        }

        public Empleado()
        {

        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string ApellidoUno
        {
            get
            {
                return apellidoUno;
            }

            set
            {
                apellidoUno = value;
            }
        }

        public string ApellidoDos
        {
            get
            {
                return apellidoDos;
            }

            set
            {
                apellidoDos = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }

            set
            {
                contrasena = value;
            }
        }

        public string Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }
    }
}
