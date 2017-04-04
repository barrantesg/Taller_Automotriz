using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Clase
    {
        //atributo
        private string descripcion;
        private int id;

        //constructor
        public Clase(string pDescripcion)
        {
            this.Descripcion = pDescripcion;
        }

        public Clase(int pId, string pDescripcion)
        {
            this.id = pId;
            this.descripcion = pDescripcion;
        }

        //get y set
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Id
        {
            get { return id; }
        }

        //tostring
        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
