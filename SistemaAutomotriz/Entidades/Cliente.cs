using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidad
{
    public class Cliente
    {
        //atributos de la clase
        private string ced;
        private string nombre;
        private string ape1;
        private string ape2;
        private string tel_ofi;
        private string tel_casa;
        private string cel;
        private string fax;
        private string direccion;
       

        //constructores
        public Cliente(string pCed, string pNombre, string pApe1, string pApe2, string pTel_ofi, string pTel_casa, string pCel, string pFax, string pDireccion)
        {
            this.ced = pCed;
            this.nombre = pNombre;
            this.ape1 = pApe1;
            this.ape2 = pApe2;
            this.tel_ofi = pTel_ofi;
            this.tel_casa = pTel_casa;
            this.cel = pCel;
            this.fax = pFax;
            this.direccion = pDireccion;
        }

        public Cliente(string pNombre, string pApe1, string pApe2, string pCel)
        {
            this.nombre = pNombre;
            this.ape1 = pApe1;
            this.ape2 = pApe2;
            this.cel = pCel;
        }

        //metodos set y get
        public string Ced
        {
            get { return ced; }
            set { ced = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Ape1
        {
            get { return ape1; }
            set { ape1 = value; }
        }

        public string Ape2
        {
            get { return ape2; }
            set { ape2 = value; }
        }

        public string Tel_ofi
        {
            get { return tel_ofi; }
            set { tel_ofi = value; }
        }

        public string  Tel_casa
        {
            get { return tel_casa; }
            set { tel_casa = value; }
        }

        public string Cel
        {
            get { return cel; }
            set { cel = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        //retornar datos de cliente
        public override string ToString()
        {
            return this.nombre+" "+this.ape1+" "+this.ape2;
        }
    }
}
