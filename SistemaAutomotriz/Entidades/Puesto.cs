using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.Entidades
{
    class Puesto
    {

        private int id;
        private string descripcion;

        public Puesto(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public Puesto()
        {
   
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }


        public override string ToString()
        {
            return this.id + " - " + this.descripcion;
        }


    }
}
