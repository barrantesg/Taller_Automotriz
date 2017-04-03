using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAutomotriz.Entidades
{
  public  class Reparacion
    {

        private int id;
        private string descripcion;
        private double cantidadHoras;
        private double costo;
     

        public Reparacion()
        {

        }

        public Reparacion(int id, string descripcion, double cantidadHoras, double costo)
        {

            this.id = id;
            this.descripcion = descripcion;
            this.cantidadHoras = cantidadHoras;
            this.costo = costo;
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

        public double CantidadHoras
        {
            get
            {
                return cantidadHoras;
            }

            set
            {
                cantidadHoras = value;
            }
        }

        public double Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
            }
        }

        public override string ToString()
        {
            return this.Id + " - " + this.Descripcion;
        }
    }
}
