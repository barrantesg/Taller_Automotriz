using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vehiculo
    {
        //atributos
        private int id;
        private string añoProd;
        private string capacidad;
        private string chasis;
        private string cilindraje;
        private int clase;
        private string combustible;
        private string motor;
        private string placa;
        private string oCliente;
        private string oMarca;
        private string oModelo;

        //get y set
        public string AñoProd
        {
            get { return añoProd; }
            set { añoProd = value; }
        }

        public string Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        public string Chasis
        {
            get { return chasis; }
            set { chasis = value; }
        }

        public string Cilindraje
        {
            get { return cilindraje; }
            set { cilindraje = value; }
        }

        public int Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public string Combustible
        {
            get { return combustible; }
            set { combustible = value; }
        }

        public string Motor
        {
            get { return motor; }
            set { motor = value; }
        }

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }

        public string OCliente
        {
            get { return oCliente; }
            set { oCliente = value; }
        }

        public string OMarca
        {
            get { return oMarca; }
            set { oMarca = value; }
        }

        public string OModelo
        {
            get { return oModelo; }
            set { oModelo = value; }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        //constructor
        public Vehiculo(string pAñoProd, string pCapacidad, string pChasis, string pCilindraje,
            int pClase, string pCombustible, string pMotor, string pPlaca, string pCliente,
            string pMarca, string pModelo)
        {
            this.añoProd = pAñoProd;
            this.capacidad = pCapacidad;
            this.chasis = pChasis;
            this.cilindraje = pCilindraje;
            this.clase = pClase;
            this.combustible = pCombustible;
            this.motor = pMotor;
            this.placa = pPlaca;
            this.oCliente = pCliente;
            this.oMarca = pMarca;
            this.oModelo = pModelo;
        }

        //tostring
        public override string ToString()
        {
            return this.añoProd + this.capacidad + this.chasis + this.cilindraje + this.clase +
            this.combustible + this.motor + this.placa + this.oCliente + this.oMarca + this.oModelo;
        }

    }
}
